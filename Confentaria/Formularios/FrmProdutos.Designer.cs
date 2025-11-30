namespace Confentaria.Formularios
{
    partial class FrmProdutos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            barraOperacao1 = new Confentaria.Formularios.ControleUsuario.BarraOperacao();
            tabProduto = new TabControl();
            tabPageProduto = new TabPage();
            groupBoxCadastro = new GroupBox();
            txtObservacoes = new TextBox();
            label8 = new Label();
            txtPrecoMedio = new TextBox();
            label7 = new Label();
            txtEstoqueAtual = new TextBox();
            label6 = new Label();
            txtUnidadeMedida = new TextBox();
            label5 = new Label();
            cmbTipo = new ComboBox();
            label1 = new Label();
            txtCodigo = new TextBox();
            labelCodigo = new Label();
            txtNome = new TextBox();
            labelNome = new Label();
            txtId = new TextBox();
            labelId = new Label();
            tabPageFornecedores = new TabPage();
            dgvFornecedoresProduto = new DataGridView();
            tabProduto.SuspendLayout();
            tabPageProduto.SuspendLayout();
            groupBoxCadastro.SuspendLayout();
            tabPageFornecedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFornecedoresProduto).BeginInit();
            SuspendLayout();
            // 
            // barraOperacao1
            // 
            barraOperacao1.AutoSize = true;
            barraOperacao1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            barraOperacao1.Dock = DockStyle.Top;
            barraOperacao1.Location = new Point(0, 0);
            barraOperacao1.Name = "barraOperacao1";
            barraOperacao1.Size = new Size(538, 46);
            barraOperacao1.TabIndex = 9;
            // 
            // tabProduto
            // 
            tabProduto.Controls.Add(tabPageProduto);
            tabProduto.Controls.Add(tabPageFornecedores);
            tabProduto.Dock = DockStyle.Fill;
            tabProduto.Location = new Point(0, 46);
            tabProduto.Name = "tabProduto";
            tabProduto.SelectedIndex = 0;
            tabProduto.Size = new Size(538, 375);
            tabProduto.TabIndex = 11;
            // 
            // tabPageProduto
            // 
            tabPageProduto.Controls.Add(groupBoxCadastro);
            tabPageProduto.Location = new Point(4, 24);
            tabPageProduto.Name = "tabPageProduto";
            tabPageProduto.Padding = new Padding(3);
            tabPageProduto.Size = new Size(530, 347);
            tabPageProduto.TabIndex = 0;
            tabPageProduto.Text = "Produto";
            tabPageProduto.UseVisualStyleBackColor = true;
            // 
            // groupBoxCadastro
            // 
            groupBoxCadastro.AutoSize = true;
            groupBoxCadastro.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxCadastro.Controls.Add(txtObservacoes);
            groupBoxCadastro.Controls.Add(label8);
            groupBoxCadastro.Controls.Add(txtPrecoMedio);
            groupBoxCadastro.Controls.Add(label7);
            groupBoxCadastro.Controls.Add(txtEstoqueAtual);
            groupBoxCadastro.Controls.Add(label6);
            groupBoxCadastro.Controls.Add(txtUnidadeMedida);
            groupBoxCadastro.Controls.Add(label5);
            groupBoxCadastro.Controls.Add(cmbTipo);
            groupBoxCadastro.Controls.Add(label1);
            groupBoxCadastro.Controls.Add(txtCodigo);
            groupBoxCadastro.Controls.Add(labelCodigo);
            groupBoxCadastro.Controls.Add(txtNome);
            groupBoxCadastro.Controls.Add(labelNome);
            groupBoxCadastro.Controls.Add(txtId);
            groupBoxCadastro.Controls.Add(labelId);
            groupBoxCadastro.Dock = DockStyle.Fill;
            groupBoxCadastro.Location = new Point(3, 3);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(524, 341);
            groupBoxCadastro.TabIndex = 11;
            groupBoxCadastro.TabStop = false;
            groupBoxCadastro.Text = "Cadastro";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Location = new Point(10, 200);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.Size = new Size(500, 80);
            txtObservacoes.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 182);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 17;
            label8.Text = "Observações:";
            // 
            // txtPrecoMedio
            // 
            txtPrecoMedio.Location = new Point(260, 150);
            txtPrecoMedio.Name = "txtPrecoMedio";
            txtPrecoMedio.Size = new Size(120, 23);
            txtPrecoMedio.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(260, 132);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 15;
            label7.Text = "Preço Médio:";
            // 
            // txtEstoqueAtual
            // 
            txtEstoqueAtual.Location = new Point(130, 150);
            txtEstoqueAtual.Name = "txtEstoqueAtual";
            txtEstoqueAtual.Size = new Size(120, 23);
            txtEstoqueAtual.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(130, 132);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 13;
            label6.Text = "Estoque Atual:";
            // 
            // txtUnidadeMedida
            // 
            txtUnidadeMedida.Location = new Point(10, 150);
            txtUnidadeMedida.Name = "txtUnidadeMedida";
            txtUnidadeMedida.Size = new Size(110, 23);
            txtUnidadeMedida.TabIndex = 12;
            txtUnidadeMedida.Text = "kg";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 132);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 11;
            label5.Text = "Unidade Medida:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(10, 100);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 23);
            cmbTipo.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 82);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 9;
            label1.Text = "Tipo:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(230, 50);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(150, 23);
            txtCodigo.TabIndex = 8;
            // 
            // labelCodigo
            // 
            labelCodigo.AutoSize = true;
            labelCodigo.Location = new Point(230, 32);
            labelCodigo.Name = "labelCodigo";
            labelCodigo.Size = new Size(49, 15);
            labelCodigo.TabIndex = 7;
            labelCodigo.Text = "Código:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(80, 50);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(140, 23);
            txtNome.TabIndex = 6;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(80, 32);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(43, 15);
            labelNome.TabIndex = 5;
            labelNome.Text = "Nome:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(10, 50);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(60, 23);
            txtId.TabIndex = 4;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(10, 32);
            labelId.Name = "labelId";
            labelId.Size = new Size(21, 15);
            labelId.TabIndex = 3;
            labelId.Text = "ID:";
            // 
            // tabPageFornecedores
            // 
            tabPageFornecedores.Controls.Add(dgvFornecedoresProduto);
            tabPageFornecedores.Location = new Point(4, 24);
            tabPageFornecedores.Name = "tabPageFornecedores";
            tabPageFornecedores.Padding = new Padding(3);
            tabPageFornecedores.Size = new Size(530, 347);
            tabPageFornecedores.TabIndex = 1;
            tabPageFornecedores.Text = "Fornecedores";
            tabPageFornecedores.UseVisualStyleBackColor = true;
            // 
            // dgvFornecedoresProduto
            // 
            dgvFornecedoresProduto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFornecedoresProduto.Dock = DockStyle.Fill;
            dgvFornecedoresProduto.Location = new Point(3, 3);
            dgvFornecedoresProduto.Name = "dgvFornecedoresProduto";
            dgvFornecedoresProduto.Size = new Size(524, 341);
            dgvFornecedoresProduto.TabIndex = 0;
            // 
            // FrmProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 421);
            Controls.Add(tabProduto);
            Controls.Add(barraOperacao1);
            Name = "FrmProdutos";
            Text = "Cadastro de Produtos";
            WindowState = FormWindowState.Maximized;
            tabProduto.ResumeLayout(false);
            tabPageProduto.ResumeLayout(false);
            tabPageProduto.PerformLayout();
            groupBoxCadastro.ResumeLayout(false);
            groupBoxCadastro.PerformLayout();
            tabPageFornecedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFornecedoresProduto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ControleUsuario.BarraOperacao barraOperacao1;
        private TabControl tabProduto;
        private TabPage tabPageProduto;
        private GroupBox groupBoxCadastro;
        private TextBox txtObservacoes;
        private Label label8;
        private TextBox txtPrecoMedio;
        private Label label7;
        private TextBox txtEstoqueAtual;
        private Label label6;
        private TextBox txtUnidadeMedida;
        private Label label5;
        private ComboBox cmbTipo;
        private Label label1;
        private TextBox txtCodigo;
        private Label labelCodigo;
        private TextBox txtNome;
        private Label labelNome;
        private TextBox txtId;
        private Label labelId;
        private TabPage tabPageFornecedores;
        private DataGridView dgvFornecedoresProduto;
    }
}
