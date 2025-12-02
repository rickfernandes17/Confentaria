using Confentaria.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Confentaria.Formularios
{
    public partial class FrmPesquisa : Form
    {
        private ConfentariaDbContext? _context;
        private Type? _entityType;
        private object? _itemSelecionado;

        public FrmPesquisa()
        {
            InitializeComponent();

            // Eventos
            btnPesquisar.Click += BtnPesquisar_Click;
            txtPesquisa.KeyPress += TxtPesquisa_KeyPress;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            // Configurações do DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Retorna o item selecionado pelo usuário
        /// </summary>
        public object? ItemSelecionado => _itemSelecionado;

        /// <summary>
        /// Configura o formulário para trabalhar com a entidade TEntity e o DbContext fornecido.
        /// Chame antes de mostrar o formulário para que o combo seja preenchido ao pesquisar.
        /// </summary>
        public void ConfigurarPara<TEntity>(ConfentariaDbContext context)
            where TEntity : class
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityType = typeof(TEntity);

            PreencherComboPropriedades();
        }

        /// <summary>
        /// Preenche o ComboBox com as propriedades da entidade que podem ser pesquisadas
        /// </summary>
        private void PreencherComboPropriedades()
        {
            if (_entityType == null) return;

            cmbPropriedades.Items.Clear();
            cmbPropriedades.DisplayMember = "Text";
            cmbPropriedades.ValueMember = "Value";

            var propriedades = _entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string) ||
                           p.PropertyType == typeof(int) ||
                           p.PropertyType == typeof(int?) ||
                           p.PropertyType.IsEnum)
                .Select(p => new { Text = p.Name, Value = p.Name })
                .ToList();

            foreach (var prop in propriedades)
            {
                cmbPropriedades.Items.Add(prop);
            }

            if (cmbPropriedades.Items.Count > 0)
            {
                cmbPropriedades.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Executa a pesquisa
        /// </summary>
        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            ExecutarPesquisa();
        }

        /// <summary>
        /// Permite pesquisar ao pressionar Enter
        /// </summary>
        private void TxtPesquisa_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ExecutarPesquisa();
            }
        }

        /// <summary>
        /// Executa a pesquisa no banco de dados
        /// </summary>
        private void ExecutarPesquisa()
        {
            try
            {
                if (_context == null || _entityType == null)
                {
                    MessageBox.Show("O formulário não foi configurado corretamente!",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbPropriedades.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um campo para pesquisar!",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var propriedadeSelecionada = ((dynamic)cmbPropriedades.SelectedItem).Value.ToString();
                var textoPesquisa = txtPesquisa.Text.Trim();

                // Obtém o DbSet da entidade
                var dbSetProperty = _context.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                        p.PropertyType.GetGenericArguments()[0] == _entityType);

                if (dbSetProperty == null)
                {
                    MessageBox.Show("Não foi possível acessar os dados!",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dbSet = dbSetProperty.GetValue(_context) as IQueryable<object>;
                if (dbSet == null) return;

                // Realiza a pesquisa
                IQueryable<object> resultado;

                if (string.IsNullOrWhiteSpace(textoPesquisa))
                {
                    // Se não houver texto, traz todos
                    resultado = dbSet;
                }
                else
                {
                    // Filtra pela propriedade selecionada
                    var propriedade = _entityType.GetProperty(propriedadeSelecionada);
                    if (propriedade == null) return;

                    resultado = dbSet.AsEnumerable()
                        .Where(item =>
                        {
                            var valor = propriedade.GetValue(item);
                            if (valor == null) return false;

                            return valor.ToString()!
                                .Contains(textoPesquisa, StringComparison.OrdinalIgnoreCase);
                        })
                        .AsQueryable();
                }

                // Converte para lista e exibe no grid
                var lista = resultado.ToList();
                dataGridView1.DataSource = lista;

                // Oculta colunas de navegação e datas se necessário
                OcultarColunasNavegacao();

                // Exibe mensagem se não encontrou resultados
                if (lista.Count == 0)
                {
                    MessageBox.Show("Nenhum registro encontrado!",
                        "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Oculta colunas de navegação (relacionamentos)
        /// </summary>
        private void OcultarColunasNavegacao()
        {
            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                // Oculta colunas de navegação (relacionamentos)
                if (coluna.Name.EndsWith("s") && coluna.ValueType != typeof(string))
                {
                    coluna.Visible = false;
                }
            }
        }

        /// <summary>
        /// Seleciona o item ao dar duplo clique
        /// </summary>
        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            SelecionarItemAtual();
        }

        /// <summary>
        /// Seleciona o item atual do grid e fecha o formulário
        /// </summary>
        private void SelecionarItemAtual()
        {
            if (dataGridView1.CurrentRow?.DataBoundItem != null)
            {
                _itemSelecionado = dataGridView1.CurrentRow.DataBoundItem;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Adiciona um botão Selecionar (opcional)
        /// </summary>
        public void AdicionarBotaoSelecionar()
        {
            var btnSelecionar = new Button
            {
                Text = "Selecionar",
                Location = new System.Drawing.Point(755, 11),
                Size = new System.Drawing.Size(90, 23)
            };
            btnSelecionar.Click += (s, e) => SelecionarItemAtual();
            Controls.Add(btnSelecionar);

            // Ajusta o tamanho do formulário
            ClientSize = new System.Drawing.Size(ClientSize.Width + 100, ClientSize.Height);
        }
    }
}