using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    public partial class FrmNotasFiscais : Form
    {
        private ConfentariaDbContext? _context;
        private NotaFiscal? _notaFiscalSelecionada;

        public FrmNotasFiscais()
        {
            InitializeComponent();
            CarregarFornecedores();
            CarregarDados();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                // Desabilitar evento temporariamente para evitar preenchimento automático
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
                    nf.ValorTotal
                }).ToList();

                dgvNotasFiscais.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNotasFiscais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNotasFiscais.MultiSelect = false;
                dgvNotasFiscais.ReadOnly = true;

                // Limpar seleção
                dgvNotasFiscais.ClearSelection();
                
                LimparCampos();
                
                // Reabilitar evento
                dgvNotasFiscais.SelectionChanged += dgvNotasFiscais_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reabilitar evento mesmo em caso de erro
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
            btnExcluir.Enabled = false;
            btnSalvar.Text = "Salvar";
            CarregarItensNota();
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
            btnExcluir.Enabled = true;
            btnSalvar.Text = "Atualizar";
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
                    Produto = i.FornecedorProduto != null ? i.FornecedorProduto.Produto.Nome : i.DescricaoOriginal,
                    i.Quantidade,
                    i.ValorUnitario,
                    i.ValorTotal,
                    Associado = i.FornecedorProduto != null ? "Sim" : "Não"
                }).ToList();
            }
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
                    MessageBox.Show("Selecione um fornecedor!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbFornecedor.Focus();
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
                        MessageBox.Show("Nota fiscal não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CarregarDados();
                        return;
                    }
                    notaFiscal.FornecedorId = fornecedorId;
                    notaFiscal.DataEmissao = dtpDataEmissao.Value;
                }

                notaFiscal.Numero = string.IsNullOrWhiteSpace(txtNumero.Text) ? null : txtNumero.Text.Trim();
                notaFiscal.Serie = string.IsNullOrWhiteSpace(txtSerie.Text) ? null : txtSerie.Text.Trim();
                notaFiscal.Url = string.IsNullOrWhiteSpace(txtUrl.Text) ? null : txtUrl.Text.Trim();

                if (decimal.TryParse(txtValorTotal.Text, out decimal valor))
                    notaFiscal.ValorTotal = valor;

                notaFiscal.Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text) ? null : txtObservacoes.Text.Trim();

                _context.SaveChanges();
                MessageBox.Show("Nota fiscal salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_notaFiscalSelecionada == null)
            {
                MessageBox.Show("Selecione uma nota fiscal para excluir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir esta nota fiscal?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _context ??= DatabaseHelper.CreateDbContext();
                    var nota = _context.NotasFiscais.Find(_notaFiscalSelecionada.Id);
                    if (nota != null)
                    {
                        _context.NotasFiscais.Remove(nota);
                        _context.SaveChanges();
                        MessageBox.Show("Nota fiscal excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcessarUrl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("Informe a URL da nota fiscal!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Funcionalidade de processamento de URL será implementada com integração Python.", 
                "Em Desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisaNumero.Clear();
            dtpPesquisaInicio.Checked = false;
            dtpPesquisaFim.Checked = false;
            CarregarDados();
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

        private void FrmNotasFiscais_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}

