using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Formularios
{
    public partial class FrmProducao : Form
    {
        private ConfentariaDbContext? _context;
        private Producao? _producaoSelecionada;

        public FrmProducao()
        {
            InitializeComponent();
            CarregarReceitas();
            CarregarDados();
        }

        private void CarregarReceitas()
        {
            try
            {
                _context = DatabaseHelper.CreateDbContext();
                var receitas = _context.Receitas.OrderBy(r => r.Nome).ToList();
                cmbReceita.DataSource = receitas;
                cmbReceita.DisplayMember = "Nome";
                cmbReceita.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar receitas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                // Desabilitar evento temporariamente para evitar preenchimento automático
                dgvProducao.SelectionChanged -= dgvProducao_SelectionChanged;
                
                _context = DatabaseHelper.CreateDbContext();
                var producoes = _context.Producoes
                    .Include(p => p.Receita)
                    .OrderByDescending(p => p.DataProducao)
                    .ToList();

                dgvProducao.DataSource = producoes.Select(p => new
                {
                    p.Id,
                    Receita = p.Receita.Nome,
                    p.DataProducao,
                    p.CustoTotal,
                    p.PrecoVenda
                }).ToList();

                dgvProducao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProducao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProducao.MultiSelect = false;
                dgvProducao.ReadOnly = true;

                // Limpar seleção
                dgvProducao.ClearSelection();
                
                LimparCampos();
                
                // Reabilitar evento
                dgvProducao.SelectionChanged += dgvProducao_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reabilitar evento mesmo em caso de erro
                dgvProducao.SelectionChanged += dgvProducao_SelectionChanged;
            }
        }

        private void LimparCampos()
        {
            _producaoSelecionada = null;
            txtId.Clear();
            cmbReceita.SelectedIndex = -1;
            dtpDataProducao.Value = DateTime.Now;
            txtCustoTotal.Clear();
            txtPrecoVenda.Clear();
            txtObservacoes.Clear();
            btnExcluir.Enabled = false;
            btnSalvar.Text = "Salvar";
            CarregarItensProducao();
        }

        private void PreencherCampos(Producao producao)
        {
            _producaoSelecionada = producao;
            txtId.Text = producao.Id.ToString();
            cmbReceita.SelectedValue = producao.ReceitaId;
            dtpDataProducao.Value = producao.DataProducao;
            txtCustoTotal.Text = producao.CustoTotal.ToString("F2");
            txtPrecoVenda.Text = producao.PrecoVenda.ToString("F2");
            txtObservacoes.Text = producao.Observacoes ?? string.Empty;
            btnExcluir.Enabled = true;
            btnSalvar.Text = "Atualizar";
            CarregarItensProducao();
        }

        private void CarregarItensProducao()
        {
            if (_producaoSelecionada == null)
            {
                dgvItens.DataSource = null;
                dgvProdutosGerados.DataSource = null;
                dgvSobras.DataSource = null;
                return;
            }

            _context ??= DatabaseHelper.CreateDbContext();
            var producao = _context.Producoes
                .Include(p => p.Itens).ThenInclude(i => i.Produto)
                .Include(p => p.ProdutosGerados).ThenInclude(pg => pg.Produto)
                .Include(p => p.Sobras).ThenInclude(s => s.Produto)
                .FirstOrDefault(p => p.Id == _producaoSelecionada.Id);

            if (producao != null)
            {
                dgvItens.DataSource = producao.Itens.Select(i => new
                {
                    i.Id,
                    Produto = i.Produto.Nome,
                    i.Quantidade,
                    Unidade = i.Produto.UnidadeMedida
                }).ToList();

                dgvProdutosGerados.DataSource = producao.ProdutosGerados.Select(pg => new
                {
                    pg.Id,
                    Produto = pg.Produto.Nome,
                    pg.Quantidade,
                    Unidade = pg.Produto.UnidadeMedida
                }).ToList();

                dgvSobras.DataSource = producao.Sobras.Select(s => new
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
            cmbReceita.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReceita.SelectedValue == null)
                {
                    MessageBox.Show("Selecione uma receita!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbReceita.Focus();
                    return;
                }

                _context ??= DatabaseHelper.CreateDbContext();
                var receitaId = (int)cmbReceita.SelectedValue;

                Producao producao;
                if (_producaoSelecionada == null)
                {
                    producao = new Producao
                    {
                        ReceitaId = receitaId,
                        DataProducao = dtpDataProducao.Value
                    };
                    _context.Producoes.Add(producao);
                }
                else
                {
                    producao = _context.Producoes.Find(_producaoSelecionada.Id);
                    if (producao == null)
                    {
                        MessageBox.Show("Produção não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CarregarDados();
                        return;
                    }
                    producao.ReceitaId = receitaId;
                    producao.DataProducao = dtpDataProducao.Value;
                }

                if (decimal.TryParse(txtCustoTotal.Text, out decimal custo))
                    producao.CustoTotal = custo;

                if (decimal.TryParse(txtPrecoVenda.Text, out decimal preco))
                    producao.PrecoVenda = preco;

                producao.Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text) ? null : txtObservacoes.Text.Trim();

                _context.SaveChanges();
                MessageBox.Show("Produção salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_producaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma produção para excluir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir esta produção?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _context ??= DatabaseHelper.CreateDbContext();
                    var producao = _context.Producoes.Find(_producaoSelecionada.Id);
                    if (producao != null)
                    {
                        _context.Producoes.Remove(producao);
                        _context.SaveChanges();
                        MessageBox.Show("Produção excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcessarReceita_Click(object sender, EventArgs e)
        {
            if (cmbReceita.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma receita primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context ??= DatabaseHelper.CreateDbContext();
                var receitaId = (int)cmbReceita.SelectedValue;
                var receita = _context.Receitas
                    .Include(r => r.Itens).ThenInclude(i => i.Produto)
                    .Include(r => r.ProdutosGerados).ThenInclude(pg => pg.Produto)
                    .Include(r => r.Sobras).ThenInclude(s => s.Produto)
                    .FirstOrDefault(r => r.Id == receitaId);

                if (receita == null)
                {
                    MessageBox.Show("Receita não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Criar produção baseada na receita
                var producao = new Producao
                {
                    ReceitaId = receitaId,
                    DataProducao = dtpDataProducao.Value,
                    CustoTotal = receita.CustoTotal,
                    PrecoVenda = receita.PrecoVendaSugerido
                };

                // Copiar itens da receita
                foreach (var item in receita.Itens)
                {
                    producao.Itens.Add(new ProducaoItem
                    {
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade,
                        CustoUnitario = item.CustoUnitario
                    });

                    // Atualizar estoque (descontar)
                    var produto = _context.Produtos.Find(item.ProdutoId);
                    if (produto != null)
                    {
                        produto.EstoqueAtual -= item.Quantidade;
                    }
                }

                // Copiar produtos gerados
                foreach (var pg in receita.ProdutosGerados)
                {
                    producao.ProdutosGerados.Add(new ProducaoProdutoGerado
                    {
                        ProdutoId = pg.ProdutoId,
                        Quantidade = pg.Quantidade
                    });

                    // Atualizar estoque (adicionar)
                    var produto = _context.Produtos.Find(pg.ProdutoId);
                    if (produto != null)
                    {
                        produto.EstoqueAtual += pg.Quantidade;
                    }
                }

                // Copiar sobras
                foreach (var sobra in receita.Sobras)
                {
                    producao.Sobras.Add(new ProducaoSobra
                    {
                        ProdutoId = sobra.ProdutoId,
                        Quantidade = sobra.Quantidade
                    });

                    // Atualizar estoque (adicionar)
                    var produto = _context.Produtos.Find(sobra.ProdutoId);
                    if (produto != null)
                    {
                        produto.EstoqueAtual += sobra.Quantidade;
                    }
                }

                _context.Producoes.Add(producao);
                _context.SaveChanges();

                txtCustoTotal.Text = producao.CustoTotal.ToString("F2");
                txtPrecoVenda.Text = producao.PrecoVenda.ToString("F2");
                MessageBox.Show("Produção processada com sucesso! Estoque atualizado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar receita: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            dtpPesquisaInicio.Checked = false;
            dtpPesquisaFim.Checked = false;
            CarregarDados();
        }

        private void dgvProducao_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducao.SelectedRows.Count > 0)
            {
                var id = (int)dgvProducao.SelectedRows[0].Cells["Id"].Value;
                _context ??= DatabaseHelper.CreateDbContext();
                var producao = _context.Producoes.Find(id);
                if (producao != null)
                {
                    PreencherCampos(producao);
                }
            }
        }

        private void FrmProducao_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}

