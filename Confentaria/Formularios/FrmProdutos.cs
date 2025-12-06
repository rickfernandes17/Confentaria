using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    public partial class FrmProdutos : Form
    {
        private ConfentariaDbContext? _context;
        private Produto? _produtoSelecionado;

        public FrmProdutos()
        {
            InitializeComponent();
            barraOperacao1.OnAdicionar += btnNovo_Click;
            barraOperacao1.OnSalvar += btnSalvar_Click;
            barraOperacao1.OnExcluir += btnExcluir_Click;
            barraOperacao1.OnPesquisar += btnPesquisar_Click;

            // Carrega os tipos de produto ao inicializar
            Load += FrmProdutos_Load;
        }

        private void FrmProdutos_Load(object? sender, EventArgs e)
        {
            CarregarTiposProduto();
        }

        /// <summary>
        /// Carrega os tipos de produto no ComboBox
        /// </summary>
        private void CarregarTiposProduto()
        {
            try
            {
                // Cria uma lista de objetos anônimos com o valor e texto do enum
                var tiposProduto = Enum.GetValues(typeof(TipoProduto))
                    .Cast<TipoProduto>()
                    .Select(t => new
                    {
                        Value = (int)t,
                        Text = ObterDescricaoTipoProduto(t)
                    })
                    .ToList();

                cmbTipo.DataSource = tiposProduto;
                cmbTipo.DisplayMember = "Text";
                cmbTipo.ValueMember = "Value";
                cmbTipo.SelectedIndex = -1; // Deixa sem seleção inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tipos de produto: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Converte o enum TipoProduto em uma descrição amigável
        /// </summary>
        private string ObterDescricaoTipoProduto(TipoProduto tipo)
        {
            return tipo switch
            {
                TipoProduto.Ingrediente => "Ingrediente",
                TipoProduto.MateriaPrimaPronta => "Matéria Prima Pronta",
                TipoProduto.Sobra => "Sobra",
                _ => tipo.ToString()
            };
        }

        /// <summary>
        /// Carrega os fornecedores do produto no DataGridView
        /// </summary>
        private void CarregarFornecedoresProduto(int produtoId)
        {
            try
            {
                _context ??= DatabaseHelper.CreateDbContext();

                // Configura as colunas do DataGridView se ainda não foram configuradas
                if (dgvFornecedoresProduto.Columns.Count == 0)
                {
                    ConfigurarColunasFornecedores();
                }

                // Limpa o grid
                dgvFornecedoresProduto.Rows.Clear();

                // Busca os fornecedores do produto com Include para carregar os dados do fornecedor
                var fornecedoresProduto = _context.FornecedorProdutos
                    .Include(fp => fp.Fornecedor)
                    .Where(fp => fp.ProdutoId == produtoId)
                    .OrderBy(fp => fp.Fornecedor.Nome)
                    .ToList();

                // Preenche o grid
                foreach (var fp in fornecedoresProduto)
                {
                    var row = dgvFornecedoresProduto.Rows.Add();
                    dgvFornecedoresProduto.Rows[row].Cells["ColFornecedorId"].Value = fp.FornecedorId;
                    dgvFornecedoresProduto.Rows[row].Cells["ColNomeFornecedor"].Value = fp.Fornecedor.Nome;
                    dgvFornecedoresProduto.Rows[row].Cells["ColCodigoFornecedor"].Value = fp.CodigoFornecedor ?? string.Empty;
                    dgvFornecedoresProduto.Rows[row].Cells["ColDescricaoFornecedor"].Value = fp.DescricaoFornecedor ?? string.Empty;
                    dgvFornecedoresProduto.Rows[row].Cells["ColPrecoUnitario"].Value = fp.PrecoUnitario?.ToString("C2") ?? "R$ 0,00";
                    dgvFornecedoresProduto.Rows[row].Cells["ColUnidadeMedida"].Value = fp.UnidadeMedidaFornecedor ?? string.Empty;
                    dgvFornecedoresProduto.Rows[row].Cells["ColObservacoes"].Value = fp.Observacoes ?? string.Empty;

                    // Guarda o ID do FornecedorProduto na Tag da linha
                    dgvFornecedoresProduto.Rows[row].Tag = fp.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura as colunas do DataGridView de fornecedores
        /// </summary>
        private void ConfigurarColunasFornecedores()
        {
            dgvFornecedoresProduto.Columns.Clear();
            dgvFornecedoresProduto.AutoGenerateColumns = false;
            dgvFornecedoresProduto.AllowUserToAddRows = false;
            dgvFornecedoresProduto.ReadOnly = true;
            dgvFornecedoresProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFornecedoresProduto.MultiSelect = false;

            // Coluna ID do Fornecedor (oculta)
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColFornecedorId",
                HeaderText = "ID Fornecedor",
                Visible = false
            });

            // Coluna Nome do Fornecedor
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColNomeFornecedor",
                HeaderText = "Fornecedor",
                Width = 200
            });

            // Coluna Código do Fornecedor
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColCodigoFornecedor",
                HeaderText = "Código do Fornecedor",
                Width = 150
            });

            // Coluna Descrição do Fornecedor
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColDescricaoFornecedor",
                HeaderText = "Descrição na Nota",
                Width = 250
            });

            // Coluna Preço Unitário
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColPrecoUnitario",
                HeaderText = "Preço Unitário",
                Width = 120
            });

            // Coluna Unidade de Medida
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColUnidadeMedida",
                HeaderText = "Unidade",
                Width = 80
            });

            // Coluna Observações
            dgvFornecedoresProduto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColObservacoes",
                HeaderText = "Observações",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void LimparCampos()
        {
            _produtoSelecionado = null;
            txtId.Clear();
            txtNome.Clear();
            txtCodigo.Clear();
            cmbTipo.SelectedIndex = -1;
            txtUnidadeMedida.Text = "kg"; // Define valor padrão
            txtEstoqueAtual.Clear();
            txtPrecoMedio.Clear();
            txtObservacoes.Clear();

            // Limpa o grid de fornecedores
            dgvFornecedoresProduto.Rows.Clear();
        }

        private void PreencherCampos(Produto produto)
        {
            _produtoSelecionado = produto;
            txtId.Text = produto.Id.ToString();
            txtNome.Text = produto.Nome;
            txtCodigo.Text = produto.Codigo ?? string.Empty;
            cmbTipo.SelectedValue = (int)produto.Tipo;
            txtUnidadeMedida.Text = produto.UnidadeMedida;
            txtEstoqueAtual.Text = produto.EstoqueAtual.ToString("F3");
            txtPrecoMedio.Text = produto.PrecoMedio?.ToString("F2") ?? string.Empty;
            txtObservacoes.Text = produto.Observacoes ?? string.Empty;

            // Carrega os fornecedores do produto
            CarregarFornecedoresProduto(produto.Id);

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("O nome do produto é obrigatório!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }

                if (cmbTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o tipo do produto!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipo.Focus();
                    return;
                }

                _context ??= DatabaseHelper.CreateDbContext();

                Produto produto;
                if (_produtoSelecionado == null)
                {
                    produto = new Produto();
                    _context.Produtos.Add(produto);
                }
                else
                {
                    produto = _context.Produtos.Find(_produtoSelecionado.Id);
                    if (produto == null)
                    {
                        MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                produto.Nome = txtNome.Text.Trim();
                produto.Codigo = string.IsNullOrWhiteSpace(txtCodigo.Text) ? null : txtCodigo.Text.Trim();
                produto.Tipo = (TipoProduto)cmbTipo.SelectedValue!;
                produto.UnidadeMedida = string.IsNullOrWhiteSpace(txtUnidadeMedida.Text) ? "kg" : txtUnidadeMedida.Text.Trim();

                if (decimal.TryParse(txtEstoqueAtual.Text, out decimal estoque))
                    produto.EstoqueAtual = estoque;

                if (decimal.TryParse(txtPrecoMedio.Text, out decimal preco))
                    produto.PrecoMedio = preco;
                else
                    produto.PrecoMedio = null;

                produto.Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text) ? null : txtObservacoes.Text.Trim();
                produto.DataAtualizacao = DateTime.Now;

                _context.SaveChanges();
                MessageBox.Show("Produto salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza o produto selecionado após salvar
                _produtoSelecionado = produto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto para excluir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir o produto '{_produtoSelecionado.Nome}'?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _context ??= DatabaseHelper.CreateDbContext();
                    var produto = _context.Produtos.Find(_produtoSelecionado.Id);
                    if (produto != null)
                    {
                        _context.Produtos.Remove(produto);
                        _context.SaveChanges();
                        MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AbrirPesquisaProdutos();
        }

        private void AbrirPesquisaProdutos()
        {
            try
            {
                _context ??= DatabaseHelper.CreateDbContext();

                using var frm = new FrmPesquisa();

                // Configura o formulário para trabalhar com a entidade Produto
                frm.ConfigurarPara<Produto>(_context);

                // Opcional: adiciona botão Selecionar
                frm.AdicionarBotaoSelecionar();

                // Exibe o formulário como diálogo
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Obtém o produto selecionado
                    var produtoSelecionado = frm.ItemSelecionado as Produto;

                    if (produtoSelecionado != null)
                    {
                        // Carrega o produto completo do banco (com tracking)
                        var produto = _context.Produtos.Find(produtoSelecionado.Id);

                        if (produto != null)
                        {
                            PreencherCampos(produto);
                            MessageBox.Show($"Produto '{produto.Nome}' carregado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir pesquisa: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}