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
            chkAtualizarEstoque = new CheckBox();
            txtPesquisaProduto = new TextBox();
            lblPesquisa = new Label();
            btnProcessarNota = new Button();
            lblResumo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItensNota).BeginInit();
            SuspendLayout();
            // 
            // dgvItensNota
            // 
            dgvItensNota.AllowUserToAddRows = false;
            dgvItensNota.AllowUserToDeleteRows = false;
            dgvItensNota.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItensNota.Location = new Point(12, 85);
            dgvItensNota.MultiSelect = false;
            dgvItensNota.Name = "dgvItensNota";
            dgvItensNota.ReadOnly = true;
            dgvItensNota.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensNota.Size = new Size(976, 300);
            dgvItensNota.TabIndex = 0;
            // 
            // btnVincularSelecionado
            // 
            btnVincularSelecionado.Location = new Point(12, 440);
            btnVincularSelecionado.Name = "btnVincularSelecionado";
            btnVincularSelecionado.Size = new Size(180, 35);
            btnVincularSelecionado.TabIndex = 1;
            btnVincularSelecionado.Text = "Vincular a Produto Existente";
            btnVincularSelecionado.UseVisualStyleBackColor = true;
            // 
            // btnCriarNovo
            // 
            btnCriarNovo.Location = new Point(202, 440);
            btnCriarNovo.Name = "btnCriarNovo";
            btnCriarNovo.Size = new Size(150, 35);
            btnCriarNovo.TabIndex = 2;
            btnCriarNovo.Text = "Criar Novo Produto";
            btnCriarNovo.UseVisualStyleBackColor = true;
            // 
            // btnIgnorar
            // 
            btnIgnorar.Location = new Point(362, 440);
            btnIgnorar.Name = "btnIgnorar";
            btnIgnorar.Size = new Size(100, 35);
            btnIgnorar.TabIndex = 3;
            btnIgnorar.Text = "Ignorar";
            btnIgnorar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(888, 440);
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
            // chkAtualizarEstoque
            // 
            chkAtualizarEstoque.AutoSize = true;
            chkAtualizarEstoque.Checked = true;
            chkAtualizarEstoque.CheckState = CheckState.Checked;
            chkAtualizarEstoque.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkAtualizarEstoque.Location = new Point(12, 395);
            chkAtualizarEstoque.Name = "chkAtualizarEstoque";
            chkAtualizarEstoque.Size = new Size(274, 19);
            chkAtualizarEstoque.TabIndex = 6;
            chkAtualizarEstoque.Text = "Atualizar Estoque Automaticamente";
            chkAtualizarEstoque.UseVisualStyleBackColor = true;
            // 
            // txtPesquisaProduto
            // 
            txtPesquisaProduto.Location = new Point(12, 50);
            txtPesquisaProduto.Name = "txtPesquisaProduto";
            txtPesquisaProduto.PlaceholderText = "Pesquisar produto...";
            txtPesquisaProduto.Size = new Size(300, 23);
            txtPesquisaProduto.TabIndex = 7;
            // 
            // lblPesquisa
            // 
            lblPesquisa.AutoSize = true;
            lblPesquisa.Location = new Point(12, 32);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(103, 15);
            lblPesquisa.TabIndex = 8;
            lblPesquisa.Text = "Pesquisar Produto:";
            // 
            // btnProcessarNota
            // 
            btnProcessarNota.BackColor = Color.FromArgb(0, 120, 215);
            btnProcessarNota.FlatStyle = FlatStyle.Flat;
            btnProcessarNota.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProcessarNota.ForeColor = Color.White;
            btnProcessarNota.Location = new Point(648, 440);
            btnProcessarNota.Name = "btnProcessarNota";
            btnProcessarNota.Size = new Size(220, 35);
            btnProcessarNota.TabIndex = 9;
            btnProcessarNota.Text = "Processar Nota Completa";
            btnProcessarNota.UseVisualStyleBackColor = false;
            // 
            // lblResumo
            // 
            lblResumo.AutoSize = true;
            lblResumo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumo.ForeColor = Color.FromArgb(0, 120, 215);
            lblResumo.Location = new Point(330, 395);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new Size(224, 15);
            lblResumo.TabIndex = 10;
            lblResumo.Text = "Total: 0 | Vinculados: 0 | Não Vinculados: 0";
            // 
            // FrmVincularProdutosNota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 490);
            Controls.Add(lblResumo);
            Controls.Add(btnProcessarNota);
            Controls.Add(lblPesquisa);
            Controls.Add(txtPesquisaProduto);
            Controls.Add(chkAtualizarEstoque);
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
        private CheckBox chkAtualizarEstoque;
        private TextBox txtPesquisaProduto;
        private Label lblPesquisa;
        private Button btnProcessarNota;
        private Label lblResumo;
    }
}
