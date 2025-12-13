using Confentaria.Data;
using Confentaria.Models;
using Confentaria.Services;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    /// <summary>
    /// Formulário para vincular produtos da nota fiscal aos produtos cadastrados
    /// </summary>
    public partial class FrmVincularProdutosNota : Form
    {
        private ConfentariaDbContext _context;
        private NotaFiscal _notaFiscal;
        private EstoqueService _estoqueService;

        public FrmVincularProdutosNota(ConfentariaDbContext context, NotaFiscal notaFiscal)
        {
            _context = context;
            _notaFiscal = notaFiscal;
            _estoqueService = new EstoqueService(context);
            InitializeComponent();
            ConfigurarFormulario();
            CarregarItens();
        }

        private void ConfigurarFormulario()
        {
            // Configura eventos dos botões
            btnVincularSelecionado.Click += BtnVincularSelecionado_Click;
            btnCriarNovo.Click += BtnCriarNovo_Click;
            btnIgnorar.Click += BtnIgnorar_Click;
            btnFechar.Click += (s, e) => this.Close();
            btnProcessarNota.Click += BtnProcessarNota_Click;

            // Configura eventos de filtro
            txtPesquisaProduto.TextChanged += TxtPesquisaProduto_TextChanged;

            // Configura o DataGridView
            dgvItensNota.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItensNota.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensNota.MultiSelect = false;
            dgvItensNota.ReadOnly = true;
            dgvItensNota.AllowUserToAddRows = false;
            dgvItensNota.AllowUserToDeleteRows = false;

            // Checkbox de atualizar estoque marcado por padrão
            chkAtualizarEstoque.Checked = true;
        }

        private void CarregarItens()
        {
            var itens = _context.NotaFiscalItens
                .Include(i => i.FornecedorProduto)
                    .ThenInclude(fp => fp!.Produto)
                .Where(i => i.NotaFiscalId == _notaFiscal.Id)
                .ToList();

            dgvItensNota.DataSource = itens.Select(i => 
            {
                var quantidadeConvertida = i.Quantidade * (i.FornecedorProduto?.FatorConversao ?? 1);
                return new
                {
                    i.Id,
                    DescricaoNota = i.DescricaoOriginal,
                    CodigoNota = i.CodigoOriginal,
                    i.Quantidade,
                    i.UnidadeMedida,
                    i.ValorUnitario,
                    Status = i.FornecedorProdutoId == null ? "NÃO VINCULADO" : "VINCULADO",
                    ProdutoVinculado = i.FornecedorProduto?.Produto.Nome ?? "",
                    EstoqueAtual = i.FornecedorProduto?.Produto.EstoqueAtual.ToString("F3") ?? "-",
                    NovoEstoque = i.FornecedorProdutoId != null 
                        ? (i.FornecedorProduto!.Produto.EstoqueAtual + quantidadeConvertida).ToString("F3") 
                        : "-"
                };
            }).ToList();

            // Destaca itens não vinculados
            foreach (DataGridViewRow row in dgvItensNota.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "NÃO VINCULADO")
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            AtualizarResumo();
        }

        private void AtualizarResumo()
        {
            var totalItens = _context.NotaFiscalItens
                .Count(i => i.NotaFiscalId == _notaFiscal.Id);

            var itensVinculados = _context.NotaFiscalItens
                .Count(i => i.NotaFiscalId == _notaFiscal.Id && i.FornecedorProdutoId != null);

            var itensNaoVinculados = totalItens - itensVinculados;

            lblResumo.Text = $"Total: {totalItens} | Vinculados: {itensVinculados} | Não Vinculados: {itensNaoVinculados}";

            // Habilita botão de processar apenas se todos os itens estiverem vinculados
            //btnProcessarNota.Enabled = itensNaoVinculados == 0 && totalItens > 0;
        }

        private void TxtPesquisaProduto_TextChanged(object? sender, EventArgs e)
        {
            // Este método será usado para filtrar produtos ao pesquisar
            // Por enquanto, mantemos simples
        }

        private void BtnVincularSelecionado_Click(object? sender, EventArgs e)
        {
            if (dgvItensNota.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemId = (int)dgvItensNota.SelectedRows[0].Cells["Id"].Value;
            var item = _context.NotaFiscalItens.Find(itemId);

            if (item == null) return;

            // Abre formulário de pesquisa de produtos
            using var frmPesquisa = new FrmPesquisa();
            frmPesquisa.ConfigurarPara<Produto>(_context);
            frmPesquisa.AdicionarBotaoSelecionar();
            frmPesquisa.Text = $"Selecionar Produto para: {item.DescricaoOriginal}";

            if (frmPesquisa.ShowDialog() == DialogResult.OK)
            {
                var produto = frmPesquisa.ItemSelecionado as Produto;

                if (produto != null)
                {
                    VincularProduto(item, produto, chkAtualizarEstoque.Checked);
                    CarregarItens();
                }
            }
        }

        private void BtnCriarNovo_Click(object? sender, EventArgs e)
        {
            if (dgvItensNota.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemId = (int)dgvItensNota.SelectedRows[0].Cells["Id"].Value;
            var item = _context.NotaFiscalItens.Find(itemId);

            if (item == null) return;

            // Cria novo produto
            var novoProduto = new Produto
            {
                Nome = item.DescricaoOriginal!,
                Codigo = item.CodigoOriginal,
                UnidadeMedida = item.UnidadeMedida ?? "un",
                Tipo = TipoProduto.Ingrediente,
                PrecoMedio = item.ValorUnitario,
                DataCriacao = DateTime.Now
            };

            _context.Produtos.Add(novoProduto);
            _context.SaveChanges();

            VincularProduto(item, novoProduto, chkAtualizarEstoque.Checked);

            MessageBox.Show($"Produto '{novoProduto.Nome}' criado e vinculado com sucesso!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarItens();
        }

        private void BtnIgnorar_Click(object? sender, EventArgs e)
        {
            if (dgvItensNota.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Item ignorado. Você pode vinculá-lo posteriormente.",
                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnProcessarNota_Click(object? sender, EventArgs e)
        {
            if (_notaFiscal.DataProcessamento != null)
            {
                MessageBox.Show("Esta nota fiscal já foi processada anteriormente!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var totalItens = _context.NotaFiscalItens
                .Count(i => i.NotaFiscalId == _notaFiscal.Id);

            var itensVinculados = _context.NotaFiscalItens
                .Count(i => i.NotaFiscalId == _notaFiscal.Id && i.FornecedorProdutoId != null);

            var itensNaoVinculados = totalItens - itensVinculados;

            if (itensVinculados == 0)
            {
                MessageBox.Show("Nenhum item foi vinculado! Vincule pelo menos um item para processar a nota.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var atualizarEstoque = chkAtualizarEstoque.Checked;
            
            var mensagemConfirmacao = $"PROCESSAMENTO DA NOTA FISCAL\n\n" +
                $"Total de itens: {totalItens}\n" +
                $"Itens vinculados: {itensVinculados}\n" +
                $"Itens NÃO vinculados: {itensNaoVinculados}\n\n";

            if (itensNaoVinculados > 0)
            {
                mensagemConfirmacao += $"⚠ {itensNaoVinculados} item(ns) não vinculado(s) será(ão) IGNORADO(S).\n\n";
            }

            if (atualizarEstoque)
            {
                mensagemConfirmacao += $"✓ O estoque dos {itensVinculados} produtos vinculados será ATUALIZADO.\n\n";
            }
            else
            {
                mensagemConfirmacao += $"✗ O estoque NÃO será atualizado.\n\n";
            }

            mensagemConfirmacao += "Deseja continuar?";

            var resultado = MessageBox.Show(mensagemConfirmacao,
                "Confirmar Processamento",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var resultadoProcessamento = _estoqueService.ProcessarNotaFiscal(_notaFiscal, atualizarEstoque);

                    if (resultadoProcessamento.Sucesso)
                    {
                        MessageBox.Show(resultadoProcessamento.Mensagem,
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultadoProcessamento.Mensagem,
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar nota: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VincularProduto(NotaFiscalItem item, Produto produto, bool atualizarEstoque)
        {
            var fornecedorId = _notaFiscal.FornecedorId;

            // Verifica se já existe vínculo FornecedorProduto
            var vinculo = _context.FornecedorProdutos
                .FirstOrDefault(fp => fp.FornecedorId == fornecedorId &&
                                     fp.ProdutoId == produto.Id);

            decimal fatorConversao = 1;
            bool isNovoVinculo = vinculo == null;

            if (isNovoVinculo)
            {
                // Detecta se as unidades são diferentes
                var unidadeNota = (item.UnidadeMedida ?? "UN").Trim().ToUpper();
                var unidadeProduto = produto.UnidadeMedida.Trim().ToUpper();

                if (unidadeNota != unidadeProduto)
                {
                    // Solicita fator de conversão
                    using var frmConversao = new FrmFatorConversao(
                        item.UnidadeMedida ?? "UN",
                        produto.UnidadeMedida,
                        item.Quantidade
                    );

                    if (frmConversao.ShowDialog() == DialogResult.OK)
                    {
                        fatorConversao = frmConversao.FatorConversao;
                    }
                    else
                    {
                        // Usuário cancelou
                        return;
                    }
                }

                vinculo = new FornecedorProduto
                {
                    FornecedorId = fornecedorId,
                    ProdutoId = produto.Id,
                    CodigoFornecedor = item.CodigoOriginal,
                    DescricaoFornecedor = item.DescricaoOriginal,
                    PrecoUnitario = item.ValorUnitario,
                    UnidadeMedidaFornecedor = item.UnidadeMedida,
                    FatorConversao = fatorConversao,
                    DataCriacao = DateTime.Now
                };

                _context.FornecedorProdutos.Add(vinculo);
                _context.SaveChanges();
            }
            else
            {
                // Usa o fator de conversão já existente
                fatorConversao = vinculo.FatorConversao ?? 1;

                // Atualiza o preço se mudou
                if (vinculo.PrecoUnitario != item.ValorUnitario)
                {
                    vinculo.PrecoUnitario = item.ValorUnitario;
                    vinculo.DataAtualizacao = DateTime.Now;
                    _context.SaveChanges();
                }
            }

            // Vincula o item ao FornecedorProduto
            item.FornecedorProdutoId = vinculo.Id;
            _context.SaveChanges();

            // Calcula quantidade convertida
            var quantidadeConvertida = item.Quantidade * fatorConversao;

            // Atualiza estoque se solicitado
            if (atualizarEstoque)
            {
                _estoqueService.AtualizarEstoque(produto, quantidadeConvertida, item.ValorUnitario, _notaFiscal.Id);
                
                var mensagem = $"Produto vinculado e estoque atualizado!\n" +
                              $"Estoque anterior: {produto.EstoqueAtual - quantidadeConvertida:F3} {produto.UnidadeMedida}\n" +
                              $"Novo estoque: {produto.EstoqueAtual:F3} {produto.UnidadeMedida}";

                if (fatorConversao != 1)
                {
                    mensagem += $"\n\nConversão aplicada: {item.Quantidade:F3} {item.UnidadeMedida} × {fatorConversao:F3} = {quantidadeConvertida:F3} {produto.UnidadeMedida}";
                }

                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var mensagem = $"Produto vinculado com sucesso!";
                
                if (fatorConversao != 1)
                {
                    mensagem += $"\n\nFator de conversão: {fatorConversao:F3}";
                }

                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
