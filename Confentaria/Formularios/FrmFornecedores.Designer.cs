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
            barraOperacao1 = new Confentaria.Formularios.ControleUsuario.BarraOperacao();
            groupBoxCadastro.SuspendLayout();
            SuspendLayout();
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
            groupBoxCadastro.Dock = DockStyle.Fill;
            groupBoxCadastro.Location = new Point(0, 46);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(1000, 654);
            groupBoxCadastro.TabIndex = 1;
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
            label6.Size = new Size(55, 15);
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
            label4.Size = new Size(63, 15);
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
            // barraOperacao1
            // 
            barraOperacao1.AutoSize = true;
            barraOperacao1.Dock = DockStyle.Top;
            barraOperacao1.Location = new Point(0, 0);
            barraOperacao1.Name = "barraOperacao1";
            barraOperacao1.Size = new Size(1000, 46);
            barraOperacao1.TabIndex = 20;
            // 
            // FrmFornecedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(groupBoxCadastro);
            Controls.Add(barraOperacao1);
            Name = "FrmFornecedores";
            Text = "Cadastro de Fornecedores";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmFornecedores_FormClosing;
            groupBoxCadastro.ResumeLayout(false);
            groupBoxCadastro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private ControleUsuario.BarraOperacao barraOperacao1;
    }
}

