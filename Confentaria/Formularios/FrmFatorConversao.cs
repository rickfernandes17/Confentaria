using System;
using System.Windows.Forms;

namespace Confentaria.Formularios
{
    /// <summary>
    /// Formulário para definir o fator de conversão entre unidades diferentes
    /// </summary>
    public partial class FrmFatorConversao : Form
    {
        public decimal FatorConversao { get; private set; } = 1;

        private string _unidadeNota;
        private string _unidadeProduto;
        private decimal _quantidadeNota;

        public FrmFatorConversao(string unidadeNota, string unidadeProduto, decimal quantidadeNota)
        {
            _unidadeNota = unidadeNota;
            _unidadeProduto = unidadeProduto;
            _quantidadeNota = quantidadeNota;
            
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Conversão de Unidades";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(450, 280);

            // Label de aviso
            var lblAviso = new Label
            {
                Text = "⚠ ATENÇÃO: Unidades diferentes detectadas!",
                Location = new Point(20, 20),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DarkOrange
            };

            // Label de explicação
            var lblExplicacao = new Label
            {
                Text = $"A nota fiscal está em '{_unidadeNota}' mas o produto está cadastrado em '{_unidadeProduto}'.\n\n" +
                       $"Defina quantas unidades de '{_unidadeProduto}' equivalem a 1 '{_unidadeNota}':",
                Location = new Point(20, 55),
                Size = new Size(400, 60),
                Font = new Font("Segoe UI", 9F)
            };

            // Label "1"
            var lblUm = new Label
            {
                Text = "1",
                Location = new Point(20, 130),
                Size = new Size(30, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            // Label unidade nota
            var lblUnidadeNota = new Label
            {
                Text = _unidadeNota,
                Location = new Point(55, 130),
                Size = new Size(60, 25),
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Label "="
            var lblIgual = new Label
            {
                Text = "=",
                Location = new Point(120, 130),
                Size = new Size(20, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // TextBox para fator
            var txtFator = new NumericUpDown
            {
                Name = "txtFator",
                Location = new Point(145, 128),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10F),
                DecimalPlaces = 3,
                Minimum = 0.001M,
                Maximum = 999999M,
                Value = 1,
                TextAlign = HorizontalAlignment.Center
            };

            // Label unidade produto
            var lblUnidadeProduto = new Label
            {
                Text = _unidadeProduto,
                Location = new Point(230, 130),
                Size = new Size(60, 25),
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Label de preview
            var lblPreview = new Label
            {
                Name = "lblPreview",
                Text = "",
                Location = new Point(20, 165),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.Gray
            };

            // Atualizar preview quando mudar o valor
            txtFator.ValueChanged += (s, e) =>
            {
                var fator = txtFator.Value;
                var quantidadeConvertida = _quantidadeNota * fator;
                lblPreview.Text = $"Exemplo: {_quantidadeNota:F3} {_unidadeNota} × {fator:F3} = {quantidadeConvertida:F3} {_unidadeProduto}";
            };

            // Disparar o evento inicial
            txtFator.Value = 1.001M; // Trigger
            txtFator.Value = 1M;

            // Botão Confirmar
            var btnConfirmar = new Button
            {
                Text = "✓ Confirmar",
                Location = new Point(150, 200),
                Size = new Size(120, 35),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.Click += (s, e) =>
            {
                if (txtFator.Value <= 0)
                {
                    MessageBox.Show("O fator de conversão deve ser maior que zero!",
                        "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FatorConversao = txtFator.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // Botão Cancelar
            var btnCancelar = new Button
            {
                Text = "✕ Cancelar",
                Location = new Point(280, 200),
                Size = new Size(120, 35),
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(220, 220, 220),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            // Adicionar controles
            this.Controls.Add(lblAviso);
            this.Controls.Add(lblExplicacao);
            this.Controls.Add(lblUm);
            this.Controls.Add(lblUnidadeNota);
            this.Controls.Add(lblIgual);
            this.Controls.Add(txtFator);
            this.Controls.Add(lblUnidadeProduto);
            this.Controls.Add(lblPreview);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);

            this.AcceptButton = btnConfirmar;
            this.CancelButton = btnCancelar;
        }
    }
}
