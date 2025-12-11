using Confentaria.Data;
using Confentaria.Models;
using Confentaria.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Confentaria.Formularios
{
    public partial class FrmNotasFiscais : Form
    {
        private ConfentariaDbContext? _context;
        private NotaFiscal? _notaFiscalSelecionada;

        public FrmNotasFiscais()
        {
            InitializeComponent();
            Load += FrmNotasFiscais_Load;
        }

        private void FrmNotasFiscais_Load(object? sender, EventArgs e)
        {
            CarregarFornecedores();
            CarregarDados();
        }

        private void btnVincularProdutos_Click(object sender, EventArgs e)
        {
            AbrirVinculacaoProdutos();
        }

        private void CarregarFornecedores()
        {
            try
            {
                _context = DatabaseHelper.CreateDbContext();
                var fornecedores = _context.Fornecedores.OrderBy(f => f.Nome).ToList();
                cmbFornecedor.DataSource = fornecedores;
                cmbFornecedor.DisplayMember = "Nome";
                cmbFornecedor.ValueMember = "Id";
                cmbFornecedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                dgvNotasFiscais.SelectionChanged -= dgvNotasFiscais_SelectionChanged;

                _context = DatabaseHelper.CreateDbContext();
                var notas = _context.NotasFiscais
                    .Include(nf => nf.Fornecedor)
                    .OrderByDescending(nf => nf.DataEmissao)
                    .ToList();

                dgvNotasFiscais.DataSource = notas.Select(nf => new
                {
                    nf.Id,
                    Fornecedor = nf.Fornecedor.Nome,
                    nf.Numero,
                    nf.DataEmissao,
                    nf.ValorTotal,
                    Processada = nf.DataProcessamento != null ? "Sim" : "Não"
                }).ToList();

                dgvNotasFiscais.ClearSelection();
                LimparCampos();

                dgvNotasFiscais.SelectionChanged += dgvNotasFiscais_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvNotasFiscais.SelectionChanged += dgvNotasFiscais_SelectionChanged;
            }
        }

        private void LimparCampos()
        {
            _notaFiscalSelecionada = null;
            txtId.Clear();
            cmbFornecedor.SelectedIndex = -1;
            txtNumero.Clear();
            txtSerie.Clear();
            dtpDataEmissao.Value = DateTime.Now;
            txtUrl.Clear();
            txtValorTotal.Clear();
            txtObservacoes.Clear();
            dgvItens.DataSource = null;
        }

        private void PreencherCampos(NotaFiscal notaFiscal)
        {
            _notaFiscalSelecionada = notaFiscal;
            txtId.Text = notaFiscal.Id.ToString();
            cmbFornecedor.SelectedValue = notaFiscal.FornecedorId;
            txtNumero.Text = notaFiscal.Numero ?? string.Empty;
            txtSerie.Text = notaFiscal.Serie ?? string.Empty;
            dtpDataEmissao.Value = notaFiscal.DataEmissao;
            txtUrl.Text = notaFiscal.Url ?? string.Empty;
            txtValorTotal.Text = notaFiscal.ValorTotal.ToString("F2");
            txtObservacoes.Text = notaFiscal.Observacoes ?? string.Empty;
            CarregarItensNota();
        }

        private void CarregarItensNota()
        {
            if (_notaFiscalSelecionada == null)
            {
                dgvItens.DataSource = null;
                return;
            }

            _context ??= DatabaseHelper.CreateDbContext();
            var nota = _context.NotasFiscais
                .Include(nf => nf.Itens)
                    .ThenInclude(i => i.FornecedorProduto)
                        .ThenInclude(fp => fp.Produto)
                .FirstOrDefault(nf => nf.Id == _notaFiscalSelecionada.Id);

            if (nota != null)
            {
                dgvItens.DataSource = nota.Itens.Select(i => new
                {
                    i.Id,
                    DescricaoNota = i.DescricaoOriginal,
                    CodigoNota = i.CodigoOriginal,
                    ProdutoVinculado = i.FornecedorProduto?.Produto.Nome ?? "NÃO VINCULADO",
                    i.Quantidade,
                    i.UnidadeMedida,
                    i.ValorUnitario,
                    i.ValorTotal
                }).ToList();

                dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Destaca itens não vinculados
                foreach (DataGridViewRow row in dgvItens.Rows)
                {
                    if (row.Cells["ProdutoVinculado"].Value.ToString() == "NÃO VINCULADO")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
        }

        // Adicione este método para abrir o formulário de vinculação
        // Você pode chamar este método através de um botão ou menu
        private void AbrirVinculacaoProdutos()
        {
            if (_notaFiscalSelecionada == null)
            {
                MessageBox.Show("Selecione uma nota fiscal!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _context ??= DatabaseHelper.CreateDbContext();

            using var frmVincular = new FrmVincularProdutosNota(_context, _notaFiscalSelecionada);
            frmVincular.ShowDialog();

            // Recarrega os itens após fechar o formulário de vinculação
            CarregarItensNota();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            cmbFornecedor.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFornecedor.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um fornecedor!", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _context ??= DatabaseHelper.CreateDbContext();
                var fornecedorId = (int)cmbFornecedor.SelectedValue;

                NotaFiscal notaFiscal;
                if (_notaFiscalSelecionada == null)
                {
                    notaFiscal = new NotaFiscal
                    {
                        FornecedorId = fornecedorId,
                        DataEmissao = dtpDataEmissao.Value
                    };
                    _context.NotasFiscais.Add(notaFiscal);
                }
                else
                {
                    notaFiscal = _context.NotasFiscais.Find(_notaFiscalSelecionada.Id);
                    if (notaFiscal == null)
                    {
                        MessageBox.Show("Nota fiscal não encontrada!",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                notaFiscal.FornecedorId = fornecedorId;
                notaFiscal.Numero = txtNumero.Text.Trim();
                notaFiscal.Serie = txtSerie.Text.Trim();
                notaFiscal.DataEmissao = dtpDataEmissao.Value;
                notaFiscal.Url = txtUrl.Text.Trim();

                if (decimal.TryParse(txtValorTotal.Text, out decimal valor))
                    notaFiscal.ValorTotal = valor;

                notaFiscal.Observacoes = txtObservacoes.Text.Trim();

                _context.SaveChanges();
                MessageBox.Show("Nota fiscal salva com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_notaFiscalSelecionada == null)
            {
                MessageBox.Show("Selecione uma nota fiscal!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Deseja realmente excluir esta nota fiscal e todos os seus itens?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _context ??= DatabaseHelper.CreateDbContext();
                    var nota = _context.NotasFiscais
                        .Include(n => n.Itens)
                        .FirstOrDefault(n => n.Id == _notaFiscalSelecionada.Id);

                    if (nota != null)
                    {
                        _context.NotasFiscais.Remove(nota);
                        _context.SaveChanges();
                        MessageBox.Show("Nota fiscal excluída com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcessarUrl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("Informe a URL da nota fiscal!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessarNotaFiscal(txtUrl.Text);
        }

        private void ProcessarNotaFiscal(string urlNota)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnProcessarUrl.Enabled = false;

                // Executa o script Python
                var dadosNota = ExecutarScriptPython(urlNota);

                if (dadosNota == null)
                {
                    MessageBox.Show("Não foi possível processar a nota fiscal!",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Processa os dados da nota
                ProcessarDadosNota(dadosNota, urlNota);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar nota: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnProcessarUrl.Enabled = true;
            }
        }

        private NotaFiscalPython? ExecutarScriptPython(string urlNota)
        {
            try
            {
                var scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "codigo.py");

                if (!File.Exists(scriptPath))
                {
                    MessageBox.Show($"Script Python não encontrado em: {scriptPath}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"\"{scriptPath}\" \"{urlNota}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = new Process { StartInfo = startInfo };
                process.Start();

                string saida = process.StandardOutput.ReadToEnd();
                string erro = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    MessageBox.Show($"Erro ao executar Python:\n{erro}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Parse do JSON retornado
                return JsonSerializer.Deserialize<NotaFiscalPython>(saida);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar script: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ProcessarDadosNota(NotaFiscalPython dadosNota, string url)
        {
            _context ??= DatabaseHelper.CreateDbContext();

            // Extrai informações do fornecedor da URL ou dados
            var fornecedor = ObterOuCriarFornecedor(dadosNota);

            if (fornecedor == null)
            {
                MessageBox.Show("Não foi possível identificar o fornecedor!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cria a nota fiscal
            var notaFiscal = new NotaFiscal
            {
                FornecedorId = fornecedor.Id,
                Numero = dadosNota.Numero,
                Serie = dadosNota.Serie,
                DataEmissao = DateTime.Parse(dadosNota.DataEmissao),
                Url = url,
                ValorTotal = dadosNota.Produtos.Sum(p => p.Quantidade * p.PrecoUnitario),
                //DataProcessamento = DateTime.Now
            };

            _context.NotasFiscais.Add(notaFiscal);
            _context.SaveChanges();

            // Processa os itens da nota
            ProcessarItensDaNota(notaFiscal, dadosNota.Produtos, fornecedor);

            MessageBox.Show($"Nota fiscal processada com sucesso!\n" +
                          $"Total de itens: {dadosNota.Produtos.Count}",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarDados();

            // Seleciona a nota recém criada
            var notaCriada = _context.NotasFiscais.Find(notaFiscal.Id);
            if (notaCriada != null)
            {
                PreencherCampos(notaCriada);
            }
        }

        private Fornecedor? ObterOuCriarFornecedor(NotaFiscalPython dadosNota)
        {
            // Tenta encontrar fornecedor existente
            var fornecedorExistente = _context!.Fornecedores
                .FirstOrDefault(f => f.Nome.Contains(dadosNota.NomeFornecedor ?? ""));

            if (fornecedorExistente != null)
            {
                return fornecedorExistente;
            }

            // Pergunta se deseja criar novo fornecedor
            var resultado = MessageBox.Show(
                $"Fornecedor '{dadosNota.NomeFornecedor}' não encontrado.\n\n" +
                "Deseja cadastrar este fornecedor?",
                "Novo Fornecedor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var novoFornecedor = new Fornecedor
                {
                    Nome = dadosNota.NomeFornecedor ?? "Fornecedor Importado",
                    CnpjCpf = dadosNota.CnpjFornecedor,
                    DataCriacao = DateTime.Now
                };

                _context.Fornecedores.Add(novoFornecedor);
                _context.SaveChanges();

                return novoFornecedor;
            }

            return null;
        }

        private void ProcessarItensDaNota(NotaFiscal notaFiscal, List<ProdutoPython> produtos, Fornecedor fornecedor)
        {
            foreach (var produtoPython in produtos)
            {
                // Cria o item da nota
                var item = new NotaFiscalItem
                {
                    NotaFiscalId = notaFiscal.Id,
                    DescricaoOriginal = produtoPython.Nome,
                    CodigoOriginal = produtoPython.Codigo,
                    Quantidade = produtoPython.Quantidade,
                    ValorUnitario = produtoPython.PrecoUnitario,
                    ValorTotal = produtoPython.Quantidade * produtoPython.PrecoUnitario,
                    UnidadeMedida = produtoPython.Unidade
                };

                _context!.NotaFiscalItens.Add(item);
                _context.SaveChanges();

                // Tenta vincular a um produto existente
                VincularProduto(item, fornecedor);
            }
        }

        private void VincularProduto(NotaFiscalItem item, Fornecedor fornecedor)
        {

            // Busca produto já vinculado através do código original
            var produtoPorCodigo = _context!.Produtos
                .Where(p => p.FornecedorProdutos.Any(fp =>
                    fp.NotaFiscalItens.Any(nfi => nfi.CodigoOriginal == item.CodigoOriginal)))
                .FirstOrDefault();

            // Busca produto similar
            var produtoSimilar = _context!.Produtos
                .FirstOrDefault(p => p.Nome.ToLower().Contains(item.DescricaoOriginal!.ToLower()) ||
                                    item.DescricaoOriginal!.ToLower().Contains(p.Nome.ToLower()));

            if (produtoPorCodigo != null )
            {
                var resultado = MessageBox.Show(
                    $"Produto da nota: {item.DescricaoOriginal}\n" +
                    $"Produto encontrado: {produtoPorCodigo.Nome}\n\n" +
                    "Deseja vincular este produto?",
                    "Vincular Produto",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    CriarVinculoFornecedorProduto(item, fornecedor, produtoPorCodigo);
                }
                else if (resultado == DialogResult.No)
                {
                    PerguntarCriarNovoProduto(item, fornecedor);
                }
            }
            else
            {
                PerguntarCriarNovoProduto(item, fornecedor);
            }
        }

        private void PerguntarCriarNovoProduto(NotaFiscalItem item, Fornecedor fornecedor)
        {
            var resultado = MessageBox.Show(
                $"Produto não encontrado: {item.DescricaoOriginal}\n\n" +
                "Deseja criar um novo produto?",
                "Novo Produto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var novoProduto = new Produto
                {
                    Nome = item.DescricaoOriginal!,
                    Codigo = item.CodigoOriginal,
                    UnidadeMedida = item.UnidadeMedida ?? "un",
                    Tipo = TipoProduto.Ingrediente,
                    DataCriacao = DateTime.Now
                };

                _context!.Produtos.Add(novoProduto);
                _context.SaveChanges();

                CriarVinculoFornecedorProduto(item, fornecedor, novoProduto);
            }
        }

        private void CriarVinculoFornecedorProduto(NotaFiscalItem item, Fornecedor fornecedor, Produto produto)
        {
            // Verifica se já existe o vínculo
            var vinculoExistente = _context!.FornecedorProdutos
                .FirstOrDefault(fp => fp.FornecedorId == fornecedor.Id && fp.ProdutoId == produto.Id);

            if (vinculoExistente == null)
            {
                vinculoExistente = new FornecedorProduto
                {
                    FornecedorId = fornecedor.Id,
                    ProdutoId = produto.Id,
                    CodigoFornecedor = item.CodigoOriginal,
                    DescricaoFornecedor = item.DescricaoOriginal,
                    PrecoUnitario = item.ValorUnitario,
                    UnidadeMedidaFornecedor = item.UnidadeMedida,
                    DataCriacao = DateTime.Now
                };

                _context.FornecedorProdutos.Add(vinculoExistente);
                _context.SaveChanges();
            }

            // Atualiza o item da nota com o vínculo
            item.FornecedorProdutoId = vinculoExistente.Id;
            _context.SaveChanges();
        }

        private void dgvNotasFiscais_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNotasFiscais.SelectedRows.Count > 0)
            {
                var id = (int)dgvNotasFiscais.SelectedRows[0].Cells["Id"].Value;
                _context ??= DatabaseHelper.CreateDbContext();
                var nota = _context.NotasFiscais.Find(id);
                if (nota != null)
                {
                    PreencherCampos(nota);
                }
            }
        }

        private void btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisaNumero.Clear();
            CarregarDados();
        }

        private void btnProcessarEstoque_Click(object sender, EventArgs e)
        {
            if (_notaFiscalSelecionada == null)
            {
                MessageBox.Show("Selecione uma nota fiscal!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_notaFiscalSelecionada.DataProcessamento != null)
            {
                MessageBox.Show("Esta nota fiscal já foi processada anteriormente!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context ??= DatabaseHelper.CreateDbContext();
                
                var itensNaoVinculados = _context.NotaFiscalItens
                    .Count(i => i.NotaFiscalId == _notaFiscalSelecionada.Id && i.FornecedorProdutoId == null);

                if (itensNaoVinculados > 0)
                {
                    MessageBox.Show($"Existem {itensNaoVinculados} itens não vinculados.\n\n" +
                                  "Vincule todos os itens antes de processar a nota!",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    "Deseja processar esta nota fiscal e atualizar o estoque de todos os produtos vinculados?\n\n" +
                    "Esta ação irá:\n" +
                    "- Adicionar as quantidades ao estoque\n" +
                    "- Recalcular o preço médio dos produtos\n" +
                    "- Marcar a nota como processada",
                    "Confirmar Processamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    var estoqueService = new EstoqueService(_context);
                    var resultadoProcessamento = estoqueService.ProcessarNotaFiscal(_notaFiscalSelecionada, true);

                    if (resultadoProcessamento.Sucesso)
                    {
                        MessageBox.Show(resultadoProcessamento.Mensagem,
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Recarrega dados para refletir mudanças
                        CarregarDados();
                        CarregarItensNota();
                    }
                    else
                    {
                        MessageBox.Show(resultadoProcessamento.Mensagem,
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar estoque: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNotasFiscais_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }

    // Classes auxiliares para deserialização do JSON do Python
    public class NotaFiscalPython
    {
        [System.Text.Json.Serialization.JsonPropertyName("nomeFornecedor")]
        public string? NomeFornecedor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cnpjFornecedor")]
        public string? CnpjFornecedor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numero")]
        public string? Numero { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("serie")]
        public string? Serie { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dataEmissao")]
        public string DataEmissao { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonPropertyName("produtos")]
        public List<ProdutoPython> Produtos { get; set; } = new();
    }

    public class ProdutoPython
    {
        [System.Text.Json.Serialization.JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("quantidade")]
        public decimal Quantidade { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidade")]
        public string? Unidade { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("precoUnitario")]
        public decimal PrecoUnitario { get; set; }
    }
}