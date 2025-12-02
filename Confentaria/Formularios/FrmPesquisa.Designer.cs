namespace Confentaria.Formularios
{
    partial class FrmPesquisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbPropriedades = new ComboBox();
            label1 = new Label();
            txtPesquisa = new TextBox();
            dataGridView1 = new DataGridView();
            btnPesquisar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cmbPropriedades
            // 
            cmbPropriedades.FormattingEnabled = true;
            cmbPropriedades.Location = new Point(58, 12);
            cmbPropriedades.Name = "cmbPropriedades";
            cmbPropriedades.Size = new Size(121, 23);
            cmbPropriedades.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Campo";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(184, 12);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "Pesquisar";
            txtPesquisa.Size = new Size(484, 23);
            txtPesquisa.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 72);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(755, 216);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(674, 11);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 4;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += BtnPesquisar_Click;
            // 
            // FrmPesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 300);
            Controls.Add(btnPesquisar);
            Controls.Add(dataGridView1);
            Controls.Add(txtPesquisa);
            Controls.Add(label1);
            Controls.Add(cmbPropriedades);
            Name = "FrmPesquisa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pesquisa";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPropriedades;
        private Label label1;
        private TextBox txtPesquisa;
        private DataGridView dataGridView1;
        private Button btnPesquisar;
    }
}