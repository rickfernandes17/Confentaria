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
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                // Desabilitar evento temporariamente para evitar preenchimento automático
                dgvFornecedores.SelectionChanged -= dgvFornecedores_SelectionChanged;
                
                _context = DatabaseHelper.CreateDbContext();
                var fornecedores = _context.Fornecedores
                    .OrderBy(f => f.Nome)
                    .ToList();

                dgvFornecedores.DataSource = fornecedores;
                dgvFornecedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvFornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFornecedores.MultiSelect = false;
                dgvFornecedores.ReadOnly = true;

                // Limpar seleção
                dgvFornecedores.ClearSelection();
                
                LimparCampos();
                
                // Reabilitar evento
                dgvFornecedores.SelectionChanged += dgvFornecedores_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reabilitar evento mesmo em caso de erro
                dgvFornecedores.SelectionChanged += dgvFornecedores_SelectionChanged;
            }
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
            btnExcluir.Enabled = false;
            btnSalvar.Text = "Salvar";
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
            btnExcluir.Enabled = true;
            btnSalvar.Text = "Atualizar";
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
                        CarregarDados();
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
                MessageBox.Show("Fornecedor salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarDados();
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
                        MessageBox.Show("Fornecedor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisaNome.Clear();
            txtPesquisaCnpjCpf.Clear();
            CarregarDados();
        }

        private void dgvFornecedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFornecedores.SelectedRows.Count > 0)
            {
                var fornecedor = dgvFornecedores.SelectedRows[0].DataBoundItem as Fornecedor;
                if (fornecedor != null)
                {
                    PreencherCampos(fornecedor);
                }
            }
        }

        private void FrmFornecedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}

