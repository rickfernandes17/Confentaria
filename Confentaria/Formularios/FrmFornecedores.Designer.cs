namespace Confentaria.Formularios
{
    partial class FrmFornecedores
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
            splitContainer1 = new SplitContainer();
            groupBoxPesquisa = new GroupBox();
            btnLimparPesquisa = new Button();
            btnPesquisar = new Button();
            txtPesquisaCnpjCpf = new TextBox();
            label3 = new Label();
            txtPesquisaNome = new TextBox();
            label2 = new Label();
            dgvFornecedores = new DataGridView();
            groupBoxCadastro = new GroupBox();
            txtObservacoes = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtTelefone = new TextBox();
            label6 = new Label();
            txtEndereco = new TextBox();
            label5 = new Label();
            txtCnpjCpf = new TextBox();
            label4 = new Label();
            txtNome = new TextBox();
            labelNome = new Label();
            txtId = new TextBox();
            labelId = new Label();
            btnExcluir = new Button();
            btnSalvar = new Button();
            btnNovo = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFornecedores).BeginInit();
            groupBoxCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            splitContainer1.SplitterDistance = 350;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBoxPesquisa);
            splitContainer1.Panel1.Controls.Add(dgvFornecedores);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxCadastro);
            // 
            // groupBoxPesquisa
            // 
            groupBoxPesquisa.Controls.Add(btnLimparPesquisa);
            groupBoxPesquisa.Controls.Add(btnPesquisar);
            groupBoxPesquisa.Controls.Add(txtPesquisaCnpjCpf);
            groupBoxPesquisa.Controls.Add(label3);
            groupBoxPesquisa.Controls.Add(txtPesquisaNome);
            groupBoxPesquisa.Controls.Add(label2);
            groupBoxPesquisa.Dock = DockStyle.Top;
            groupBoxPesquisa.Location = new Point(0, 0);
            groupBoxPesquisa.Name = "groupBoxPesquisa";
            groupBoxPesquisa.Size = new Size(1000, 80);
            groupBoxPesquisa.TabIndex = 1;
            groupBoxPesquisa.TabStop = false;
            groupBoxPesquisa.Text = "Pesquisa";
            // 
            // btnLimparPesquisa
            // 
            btnLimparPesquisa.Location = new Point(420, 45);
            btnLimparPesquisa.Name = "btnLimparPesquisa";
            btnLimparPesquisa.Size = new Size(100, 25);
            btnLimparPesquisa.TabIndex = 5;
            btnLimparPesquisa.Text = "Limpar";
            btnLimparPesquisa.UseVisualStyleBackColor = true;
            btnLimparPesquisa.Click += btnLimparPesquisa_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(310, 45);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(100, 25);
            btnPesquisar.TabIndex = 4;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // txtPesquisaCnpjCpf
            // 
            txtPesquisaCnpjCpf.Location = new Point(230, 45);
            txtPesquisaCnpjCpf.Name = "txtPesquisaCnpjCpf";
            txtPesquisaCnpjCpf.Size = new Size(200, 23);
            txtPesquisaCnpjCpf.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(230, 27);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 2;
            label3.Text = "CNPJ/CPF:";
            // 
            // txtPesquisaNome
            // 
            txtPesquisaNome.Location = new Point(10, 45);
            txtPesquisaNome.Name = "txtPesquisaNome";
            txtPesquisaNome.Size = new Size(200, 23);
            txtPesquisaNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 27);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 0;
            label2.Text = "Nome:";
            // 
            // dgvFornecedores
            // 
            dgvFornecedores.AllowUserToAddRows = false;
            dgvFornecedores.AllowUserToDeleteRows = false;
            dgvFornecedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFornecedores.Dock = DockStyle.Fill;
            dgvFornecedores.Location = new Point(0, 80);
            dgvFornecedores.Name = "dgvFornecedores";
            dgvFornecedores.ReadOnly = true;
            dgvFornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFornecedores.Size = new Size(1000, 270);
            dgvFornecedores.TabIndex = 0;
            dgvFornecedores.SelectionChanged += dgvFornecedores_SelectionChanged;
            // 
            // groupBoxCadastro
            // 
            groupBoxCadastro.Controls.Add(txtObservacoes);
            groupBoxCadastro.Controls.Add(label8);
            groupBoxCadastro.Controls.Add(txtEmail);
            groupBoxCadastro.Controls.Add(label7);
            groupBoxCadastro.Controls.Add(txtTelefone);
            groupBoxCadastro.Controls.Add(label6);
            groupBoxCadastro.Controls.Add(txtEndereco);
            groupBoxCadastro.Controls.Add(label5);
            groupBoxCadastro.Controls.Add(txtCnpjCpf);
            groupBoxCadastro.Controls.Add(label4);
            groupBoxCadastro.Controls.Add(txtNome);
            groupBoxCadastro.Controls.Add(labelNome);
            groupBoxCadastro.Controls.Add(txtId);
            groupBoxCadastro.Controls.Add(labelId);
            groupBoxCadastro.Controls.Add(btnExcluir);
            groupBoxCadastro.Controls.Add(btnSalvar);
            groupBoxCadastro.Controls.Add(btnNovo);
            groupBoxCadastro.Dock = DockStyle.Fill;
            groupBoxCadastro.Location = new Point(0, 0);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(1000, 346);
            groupBoxCadastro.TabIndex = 0;
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
            label8.Size = new Size(74, 15);
            label8.TabIndex = 17;
            label8.Text = "Observações:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(260, 150);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(260, 132);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 15;
            label7.Text = "E-mail:";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(130, 150);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(120, 23);
            txtTelefone.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(130, 132);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 13;
            label6.Text = "Telefone:";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(10, 150);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(110, 23);
            txtEndereco.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 132);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 11;
            label5.Text = "Endereço:";
            // 
            // txtCnpjCpf
            // 
            txtCnpjCpf.Location = new Point(230, 50);
            txtCnpjCpf.Name = "txtCnpjCpf";
            txtCnpjCpf.Size = new Size(150, 23);
            txtCnpjCpf.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(230, 32);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 7;
            label4.Text = "CNPJ/CPF:";
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
            // btnExcluir
            // 
            btnExcluir.Location = new Point(200, 300);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 35);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(100, 300);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(10, 300);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(100, 35);
            btnNovo.TabIndex = 0;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // FrmFornecedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(splitContainer1);
            Name = "FrmFornecedores";
            Text = "Cadastro de Fornecedores";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmFornecedores_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxPesquisa.ResumeLayout(false);
            groupBoxPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFornecedores).EndInit();
            groupBoxCadastro.ResumeLayout(false);
            groupBoxCadastro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBoxPesquisa;
        private Button btnLimparPesquisa;
        private Button btnPesquisar;
        private TextBox txtPesquisaCnpjCpf;
        private Label label3;
        private TextBox txtPesquisaNome;
        private Label label2;
        private DataGridView dgvFornecedores;
        private GroupBox groupBoxCadastro;
        private TextBox txtObservacoes;
        private Label label8;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtTelefone;
        private Label label6;
        private TextBox txtEndereco;
        private Label label5;
        private TextBox txtCnpjCpf;
        private Label label4;
        private TextBox txtNome;
        private Label labelNome;
        private TextBox txtId;
        private Label labelId;
        private Button btnExcluir;
        private Button btnSalvar;
        private Button btnNovo;
    }
}

