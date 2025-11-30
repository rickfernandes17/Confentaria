using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    public partial class FrmReceitas : Form
    {
        private ConfentariaDbContext? _context;
        private Receita? _receitaSelecionada;

        public FrmReceitas()
        {
            InitializeComponent();
        }

        private void FrmReceitas_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                // Desabilitar evento temporariamente para evitar preenchimento automático
                dgvReceitas.SelectionChanged -= dgvReceitas_SelectionChanged;
                
                _context = DatabaseHelper.CreateDbContext();
                var receitas = _context.Receitas
                    .Include(r => r.Itens)
                        .ThenInclude(i => i.Produto)
                    .Include(r => r.ProdutosGerados)
                        .ThenInclude(pg => pg.Produto)
                    .Include(r => r.Sobras)
                        .ThenInclude(s => s.Produto)
                    .OrderBy(r => r.Nome)
                    .ToList();

                dgvReceitas.DataSource = receitas;
                dgvReceitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvReceitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReceitas.MultiSelect = false;
                dgvReceitas.ReadOnly = true;

                // Limpar seleção
                dgvReceitas.ClearSelection();
                
                LimparCampos();
                
                // Reabilitar evento
                dgvReceitas.SelectionChanged += dgvReceitas_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reabilitar evento mesmo em caso de erro
                dgvReceitas.SelectionChanged += dgvReceitas_SelectionChanged;
            }
        }

        private void LimparCampos()
        {
            _receitaSelecionada = null;
            txtId.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtCustoTotal.Clear();
            txtPrecoVendaSugerido.Clear();
            txtObservacoes.Clear();
            btnExcluir.Enabled = false;
            btnSalvar.Text = "Salvar";
            CarregarItensReceita();
        }

        private void PreencherCampos(Receita receita)
        {
            _receitaSelecionada = receita;
            txtId.Text = receita.Id.ToString();
            txtNome.Text = receita.Nome;
            txtDescricao.Text = receita.Descricao ?? string.Empty;
            txtCustoTotal.Text = receita.CustoTotal.ToString("F2");
            txtPrecoVendaSugerido.Text = receita.PrecoVendaSugerido.ToString("F2");
            txtObservacoes.Text = receita.Observacoes ?? string.Empty;
            btnExcluir.Enabled = true;
            btnSalvar.Text = "Atualizar";
            CarregarItensReceita();
        }

        private void CarregarItensReceita()
        {
            if (_receitaSelecionada == null)
            {
                dgvItens.DataSource = null;
                dgvProdutosGerados.DataSource = null;
                dgvSobras.DataSource = null;
                return;
            }

            _context ??= DatabaseHelper.CreateDbContext();
            var receita = _context.Receitas
                .Include(r => r.Itens).ThenInclude(i => i.Produto)
                .Include(r => r.ProdutosGerados).ThenInclude(pg => pg.Produto)
                .Include(r => r.Sobras).ThenInclude(s => s.Produto)
                .FirstOrDefault(r => r.Id == _receitaSelecionada.Id);

            if (receita != null)
            {
                dgvItens.DataSource = receita.Itens.Select(i => new
                {
                    i.Id,
                    Produto = i.Produto.Nome,
                    i.Quantidade,
                    Unidade = i.Produto.UnidadeMedida,
                    CustoUnitario = i.CustoUnitario ?? 0
                }).ToList();

                dgvProdutosGerados.DataSource = receita.ProdutosGerados.Select(pg => new
                {
                    pg.Id,
                    Produto = pg.Produto.Nome,
                    pg.Quantidade,
                    Unidade = pg.Produto.UnidadeMedida
                }).ToList();

                dgvSobras.DataSource = receita.Sobras.Select(s => new
                {
                    s.Id,
                    Produto = s.Produto.Nome,
                    s.Quantidade,
                    Unidade = s.Produto.UnidadeMedida
                }).ToList();
            }
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
                    MessageBox.Show("O nome da receita é obrigatório!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }

                _context ??= DatabaseHelper.CreateDbContext();

                Receita receita;
                if (_receitaSelecionada == null)
                {
                    receita = new Receita();
                    _context.Receitas.Add(receita);
                }
                else
                {
                    receita = _context.Receitas.Find(_receitaSelecionada.Id);
                    if (receita == null)
                    {
                        MessageBox.Show("Receita não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CarregarDados();
                        return;
                    }
                }

                receita.Nome = txtNome.Text.Trim();
                receita.Descricao = string.IsNullOrWhiteSpace(txtDescricao.Text) ? null : txtDescricao.Text.Trim();

                if (decimal.TryParse(txtCustoTotal.Text, out decimal custo))
                    receita.CustoTotal = custo;

                if (decimal.TryParse(txtPrecoVendaSugerido.Text, out decimal preco))
                    receita.PrecoVendaSugerido = preco;

                receita.Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text) ? null : txtObservacoes.Text.Trim();
                receita.DataAtualizacao = DateTime.Now;

                _context.SaveChanges();
                MessageBox.Show("Receita salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_receitaSelecionada == null)
            {
                MessageBox.Show("Selecione uma receita para excluir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir a receita '{_receitaSelecionada.Nome}'?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _context ??= DatabaseHelper.CreateDbContext();
                    var receita = _context.Receitas.Find(_receitaSelecionada.Id);
                    if (receita != null)
                    {
                        _context.Receitas.Remove(receita);
                        _context.SaveChanges();
                        MessageBox.Show("Receita excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CarregarDados();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (_receitaSelecionada == null)
            {
                MessageBox.Show("Primeiro salve a receita antes de adicionar itens!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new FrmReceitaItem(_receitaSelecionada.Id, TipoItemReceita.Ingrediente);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarItensReceita();
            }
        }

        private void btnAdicionarProdutoGerado_Click(object sender, EventArgs e)
        {
            if (_receitaSelecionada == null)
            {
                MessageBox.Show("Primeiro salve a receita antes de adicionar produtos gerados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new FrmReceitaItem(_receitaSelecionada.Id, TipoItemReceita.ProdutoGerado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarItensReceita();
            }
        }

        private void btnAdicionarSobra_Click(object sender, EventArgs e)
        {
            if (_receitaSelecionada == null)
            {
                MessageBox.Show("Primeiro salve a receita antes de adicionar sobras!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new FrmReceitaItem(_receitaSelecionada.Id, TipoItemReceita.Sobra);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarItensReceita();
            }
        }

        private void dgvReceitas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReceitas.SelectedRows.Count > 0)
            {
                var receita = dgvReceitas.SelectedRows[0].DataBoundItem as Receita;
                if (receita != null)
                {
                    PreencherCampos(receita);
                }
            }
        }

        private void FrmReceitas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }

        private void dgvReceitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


















































































        }
    }

    public enum TipoItemReceita
    {
        Ingrediente,
        ProdutoGerado,
        Sobra
    }
}

