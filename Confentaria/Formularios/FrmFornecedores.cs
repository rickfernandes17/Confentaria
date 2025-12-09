using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    public partial class FrmFornecedores : Form
    {
        private ConfentariaDbContext? _context;
        private Fornecedor? _fornecedorSelecionado;

        public FrmFornecedores()
        {
            InitializeComponent();
            barraOperacao1.OnAdicionar += btnNovo_Click;
            barraOperacao1.OnSalvar += btnSalvar_Click;
            barraOperacao1.OnExcluir += btnExcluir_Click;
            barraOperacao1.OnPesquisar += btnPesquisar_Click;
        }


        private void LimparCampos()
        {
            _fornecedorSelecionado = null;
            txtId.Clear();
            txtNome.Clear();
            txtCnpjCpf.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtObservacoes.Clear();
        }

        private void PreencherCampos(Fornecedor fornecedor)
        {
            _fornecedorSelecionado = fornecedor;
            txtId.Text = fornecedor.Id.ToString();
            txtNome.Text = fornecedor.Nome;
            txtCnpjCpf.Text = fornecedor.CnpjCpf ?? string.Empty;
            txtEndereco.Text = fornecedor.Endereco ?? string.Empty;
            txtTelefone.Text = fornecedor.Telefone ?? string.Empty;
            txtEmail.Text = fornecedor.Email ?? string.Empty;
            txtObservacoes.Text = fornecedor.Observacoes ?? string.Empty;
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
                    MessageBox.Show("O nome do fornecedor é obrigatório!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }

                _context ??= DatabaseHelper.CreateDbContext();

                Fornecedor fornecedor;
                if (_fornecedorSelecionado == null)
                {
                    fornecedor = new Fornecedor();
                    _context.Fornecedores.Add(fornecedor);
                }
                else
                {
                    fornecedor = _context.Fornecedores.Find(_fornecedorSelecionado.Id);
                    if (fornecedor == null)
                    {
                        MessageBox.Show("Fornecedor não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                fornecedor.Nome = txtNome.Text.Trim();
                fornecedor.CnpjCpf = string.IsNullOrWhiteSpace(txtCnpjCpf.Text) ? null : txtCnpjCpf.Text.Trim();
                fornecedor.Endereco = string.IsNullOrWhiteSpace(txtEndereco.Text) ? null : txtEndereco.Text.Trim();
                fornecedor.Telefone = string.IsNullOrWhiteSpace(txtTelefone.Text) ? null : txtTelefone.Text.Trim();
                fornecedor.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                fornecedor.Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text) ? null : txtObservacoes.Text.Trim();
                fornecedor.DataAtualizacao = DateTime.Now;

                _context.SaveChanges();
                PreencherCampos(fornecedor);
                MessageBox.Show("Fornecedor salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_fornecedorSelecionado == null)
            {
                MessageBox.Show("Selecione um fornecedor para excluir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir o fornecedor '{_fornecedorSelecionado.Nome}'?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _context ??= DatabaseHelper.CreateDbContext();
                    var fornecedor = _context.Fornecedores.Find(_fornecedorSelecionado.Id);
                    if (fornecedor != null)
                    {
                        _context.Fornecedores.Remove(fornecedor);
                        _context.SaveChanges();
                        LimparCampos();
                        MessageBox.Show("Fornecedor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmFornecedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                _context ??= DatabaseHelper.CreateDbContext();
                using var frm = new FrmPesquisa();
                // Configura o formulário para trabalhar com a entidade Produto
                frm.ConfigurarPara<Fornecedor>(_context);

                //Exibe o formulário de pesquisa como diálogo modal
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var fornecedorSelecionado = frm.ItemSelecionado as Fornecedor;
                    if (fornecedorSelecionado != null)
                    {
                        // Recarrega o fornecedor do banco de dados para garantir que temos os dados mais recentes
                        var fornecedor = _context.Fornecedores.Find(fornecedorSelecionado.Id);
                        if (fornecedor != null)
                        {
                            PreencherCampos(fornecedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

