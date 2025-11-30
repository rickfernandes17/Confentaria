using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    public partial class FrmReceitaItem : Form
    {
        private readonly int _receitaId;
        private readonly TipoItemReceita _tipoItem;
        private ConfentariaDbContext? _context;

        public FrmReceitaItem(int receitaId, TipoItemReceita tipoItem)
        {
            _receitaId = receitaId;
            _tipoItem = tipoItem;
            InitializeComponent();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            try
            {
                _context = DatabaseHelper.CreateDbContext();
                
                IQueryable<Produto> query = _context.Produtos;
                
                // Filtrar por tipo conforme o tipo de item da receita
                if (_tipoItem == TipoItemReceita.Ingrediente)
                {
                    query = query.Where(p => p.Tipo == TipoProduto.Ingrediente);
                }
                else if (_tipoItem == TipoItemReceita.ProdutoGerado)
                {
                    query = query.Where(p => p.Tipo == TipoProduto.MateriaPrimaPronta);
                }
                else if (_tipoItem == TipoItemReceita.Sobra)
                {
                    query = query.Where(p => p.Tipo == TipoProduto.Sobra);
                }

                var produtos = query.OrderBy(p => p.Nome).ToList();

                cmbProduto.DataSource = produtos;
                cmbProduto.DisplayMember = "Nome";
                cmbProduto.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduto.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um produto!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtQuantidade.Text, out decimal quantidade) || quantidade <= 0)
                {
                    MessageBox.Show("Informe uma quantidade válida!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantidade.Focus();
                    return;
                }

                _context ??= DatabaseHelper.CreateDbContext();
                var produtoId = (int)cmbProduto.SelectedValue;

                switch (_tipoItem)
                {
                    case TipoItemReceita.Ingrediente:
                        var item = new ReceitaItem
                        {
                            ReceitaId = _receitaId,
                            ProdutoId = produtoId,
                            Quantidade = quantidade
                        };
                        if (decimal.TryParse(txtCustoUnitario.Text, out decimal custo))
                            item.CustoUnitario = custo;
                        _context.ReceitaItens.Add(item);
                        break;

                    case TipoItemReceita.ProdutoGerado:
                        var produtoGerado = new ReceitaProdutoGerado
                        {
                            ReceitaId = _receitaId,
                            ProdutoId = produtoId,
                            Quantidade = quantidade
                        };
                        _context.ReceitaProdutosGerados.Add(produtoGerado);
                        break;

                    case TipoItemReceita.Sobra:
                        var sobra = new ReceitaSobra
                        {
                            ReceitaId = _receitaId,
                            ProdutoId = produtoId,
                            Quantidade = quantidade
                        };
                        _context.ReceitaSobras.Add(sobra);
                        break;
                }

                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmReceitaItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}

