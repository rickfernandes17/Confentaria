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
        }

        private void LimparCampos()
        {
            _produtoSelecionado = null;
            txtId.Clear();
            txtNome.Clear();
            txtCodigo.Clear();
            cmbTipo.SelectedIndex = -1;
            txtUnidadeMedida.Clear();
            txtEstoqueAtual.Clear();
            txtPrecoMedio.Clear();
            txtObservacoes.Clear();
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

        // Exemplo de método que você pode chamar a partir de um botão "Pesquisar" no FrmProdutos
        private void AbrirPesquisaProdutos()
        {
            _context ??= DatabaseHelper.CreateDbContext();

            using var frm = new FrmPesquisa();
            //frm.ConfigurarPara<Produto>(_context);
            frm.ShowDialog();

            // Opcional: ler seleção do DataGridView (precisa expor API no FrmPesquisa se quiser retornar item selecionado)
        }

    }
}
