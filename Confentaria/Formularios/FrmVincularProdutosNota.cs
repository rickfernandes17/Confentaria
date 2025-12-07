using Confentaria.Data;
using Confentaria.Models;
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

        public FrmVincularProdutosNota(ConfentariaDbContext context, NotaFiscal notaFiscal)
        {
            _context = context;
            _notaFiscal = notaFiscal;
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

            // Configura o DataGridView
            dgvItensNota.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItensNota.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensNota.MultiSelect = false;
            dgvItensNota.ReadOnly = true;
            dgvItensNota.AllowUserToAddRows = false;
            dgvItensNota.AllowUserToDeleteRows = false;
        }

        private void CarregarItens()
        {
            var itens = _context.NotaFiscalItens
                .Include(i => i.FornecedorProduto)
                    .ThenInclude(fp => fp!.Produto)
                .Where(i => i.NotaFiscalId == _notaFiscal.Id)
                .ToList();

            dgvItensNota.DataSource = itens.Select(i => new
            {
                i.Id,
                DescricaoNota = i.DescricaoOriginal,
                CodigoNota = i.CodigoOriginal,
                i.Quantidade,
                i.UnidadeMedida,
                i.ValorUnitario,
                Status = i.FornecedorProdutoId == null ? "NÃO VINCULADO" : "VINCULADO",
                ProdutoVinculado = i.FornecedorProduto?.Produto.Nome ?? ""
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
                    VincularProduto(item, produto);
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

            VincularProduto(item, novoProduto);

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

        private void VincularProduto(NotaFiscalItem item, Produto produto)
        {
            var fornecedorId = _notaFiscal.FornecedorId;

            // Verifica se já existe vínculo FornecedorProduto
            var vinculo = _context.FornecedorProdutos
                .FirstOrDefault(fp => fp.FornecedorId == fornecedorId &&
                                     fp.ProdutoId == produto.Id);

            if (vinculo == null)
            {
                vinculo = new FornecedorProduto
                {
                    FornecedorId = fornecedorId,
                    ProdutoId = produto.Id,
                    CodigoFornecedor = item.CodigoOriginal,
                    DescricaoFornecedor = item.DescricaoOriginal,
                    PrecoUnitario = item.ValorUnitario,
                    UnidadeMedidaFornecedor = item.UnidadeMedida,
                    DataCriacao = DateTime.Now
                };

                _context.FornecedorProdutos.Add(vinculo);
                _context.SaveChanges();
            }
            else
            {
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

            MessageBox.Show($"Produto vinculado com sucesso!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}