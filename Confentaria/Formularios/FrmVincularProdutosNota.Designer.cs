namespace Confentaria.Formularios
{
    partial class FrmVincularProdutosNota
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
            dgvItensNota = new DataGridView();
            btnVincularSelecionado = new Button();
            btnCriarNovo = new Button();
            btnIgnorar = new Button();
            btnFechar = new Button();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItensNota).BeginInit();
            SuspendLayout();
            // 
            // dgvItensNota
            // 
            dgvItensNota.AllowUserToAddRows = false;
            dgvItensNota.AllowUserToDeleteRows = false;
            dgvItensNota.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItensNota.Location = new Point(12, 35);
            dgvItensNota.MultiSelect = false;
            dgvItensNota.Name = "dgvItensNota";
            dgvItensNota.ReadOnly = true;
            dgvItensNota.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensNota.Size = new Size(776, 350);
            dgvItensNota.TabIndex = 0;
            // 
            // btnVincularSelecionado
            // 
            btnVincularSelecionado.Location = new Point(12, 400);
            btnVincularSelecionado.Name = "btnVincularSelecionado";
            btnVincularSelecionado.Size = new Size(180, 35);
            btnVincularSelecionado.TabIndex = 1;
            btnVincularSelecionado.Text = "Vincular a Produto Existente";
            btnVincularSelecionado.UseVisualStyleBackColor = true;
            // 
            // btnCriarNovo
            // 
            btnCriarNovo.Location = new Point(202, 400);
            btnCriarNovo.Name = "btnCriarNovo";
            btnCriarNovo.Size = new Size(150, 35);
            btnCriarNovo.TabIndex = 2;
            btnCriarNovo.Text = "Criar Novo Produto";
            btnCriarNovo.UseVisualStyleBackColor = true;
            // 
            // btnIgnorar
            // 
            btnIgnorar.Location = new Point(362, 400);
            btnIgnorar.Name = "btnIgnorar";
            btnIgnorar.Size = new Size(100, 35);
            btnIgnorar.TabIndex = 3;
            btnIgnorar.Text = "Ignorar";
            btnIgnorar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(688, 400);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(100, 35);
            btnFechar.TabIndex = 4;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInfo.Location = new Point(12, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(349, 15);
            lblInfo.TabIndex = 5;
            lblInfo.Text = "Selecione os itens não vinculados e escolha uma ação:";
            // 
            // FrmVincularProdutosNota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblInfo);
            Controls.Add(btnFechar);
            Controls.Add(btnIgnorar);
            Controls.Add(btnCriarNovo);
            Controls.Add(btnVincularSelecionado);
            Controls.Add(dgvItensNota);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVincularProdutosNota";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vincular Produtos da Nota Fiscal";
            ((System.ComponentModel.ISupportInitialize)dgvItensNota).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItensNota;
        private Button btnVincularSelecionado;
        private Button btnCriarNovo;
        private Button btnIgnorar;
        private Button btnFechar;
        private Label lblInfo;
    }
}