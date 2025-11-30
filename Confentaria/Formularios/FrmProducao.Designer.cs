namespace Confentaria.Formularios
{
    partial class FrmProducao
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
            dtpPesquisaFim = new DateTimePicker();
            label3 = new Label();
            dtpPesquisaInicio = new DateTimePicker();
            label2 = new Label();
            dgvProducao = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBoxCadastro = new GroupBox();
            txtObservacoes = new TextBox();
            label8 = new Label();
            txtPrecoVenda = new TextBox();
            label7 = new Label();
            txtCustoTotal = new TextBox();
            label6 = new Label();
            dtpDataProducao = new DateTimePicker();
            label5 = new Label();
            cmbReceita = new ComboBox();
            label4 = new Label();
            txtId = new TextBox();
            labelId = new Label();
            btnProcessarReceita = new Button();
            btnExcluir = new Button();
            btnSalvar = new Button();
            btnNovo = new Button();
            tabPage2 = new TabPage();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            dgvItens = new DataGridView();
            groupBox2 = new GroupBox();
            dgvProdutosGerados = new DataGridView();
            groupBox3 = new GroupBox();
            dgvSobras = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducao).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBoxCadastro.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutosGerados).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSobras).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBoxPesquisa);
            splitContainer1.Panel1.Controls.Add(dgvProducao);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            // 
            // groupBoxPesquisa
            // 
            groupBoxPesquisa.Controls.Add(btnLimparPesquisa);
            groupBoxPesquisa.Controls.Add(btnPesquisar);
            groupBoxPesquisa.Controls.Add(dtpPesquisaFim);
            groupBoxPesquisa.Controls.Add(label3);
            groupBoxPesquisa.Controls.Add(dtpPesquisaInicio);
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
            // dtpPesquisaFim
            // 
            dtpPesquisaFim.Format = DateTimePickerFormat.Short;
            dtpPesquisaFim.Location = new Point(230, 45);
            dtpPesquisaFim.Name = "dtpPesquisaFim";
            dtpPesquisaFim.Size = new Size(70, 23);
            dtpPesquisaFim.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(230, 27);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 2;
            label3.Text = "Data Fim:";
            // 
            // dtpPesquisaInicio
            // 
            dtpPesquisaInicio.Format = DateTimePickerFormat.Short;
            dtpPesquisaInicio.Location = new Point(10, 45);
            dtpPesquisaInicio.Name = "dtpPesquisaInicio";
            dtpPesquisaInicio.Size = new Size(200, 23);
            dtpPesquisaInicio.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 27);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 0;
            label2.Text = "Data Início:";
            // 
            // dgvProducao
            // 
            dgvProducao.AllowUserToAddRows = false;
            dgvProducao.AllowUserToDeleteRows = false;
            dgvProducao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducao.Dock = DockStyle.Fill;
            dgvProducao.Location = new Point(0, 80);
            dgvProducao.Name = "dgvProducao";
            dgvProducao.ReadOnly = true;
            dgvProducao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducao.Size = new Size(1000, 220);
            dgvProducao.TabIndex = 0;
            dgvProducao.SelectionChanged += dgvProducao_SelectionChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 396);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBoxCadastro);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(992, 368);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados da Produção";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxCadastro
            // 
            groupBoxCadastro.Controls.Add(txtObservacoes);
            groupBoxCadastro.Controls.Add(label8);
            groupBoxCadastro.Controls.Add(txtPrecoVenda);
            groupBoxCadastro.Controls.Add(label7);
            groupBoxCadastro.Controls.Add(txtCustoTotal);
            groupBoxCadastro.Controls.Add(label6);
            groupBoxCadastro.Controls.Add(dtpDataProducao);
            groupBoxCadastro.Controls.Add(label5);
            groupBoxCadastro.Controls.Add(cmbReceita);
            groupBoxCadastro.Controls.Add(label4);
            groupBoxCadastro.Controls.Add(txtId);
            groupBoxCadastro.Controls.Add(labelId);
            groupBoxCadastro.Controls.Add(btnProcessarReceita);
            groupBoxCadastro.Controls.Add(btnExcluir);
            groupBoxCadastro.Controls.Add(btnSalvar);
            groupBoxCadastro.Controls.Add(btnNovo);
            groupBoxCadastro.Dock = DockStyle.Fill;
            groupBoxCadastro.Location = new Point(3, 3);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(986, 362);
            groupBoxCadastro.TabIndex = 0;
            groupBoxCadastro.TabStop = false;
            groupBoxCadastro.Text = "Cadastro";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Location = new Point(10, 200);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.Size = new Size(500, 100);
            txtObservacoes.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 182);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 14;
            label8.Text = "Observações:";
            // 
            // txtPrecoVenda
            // 
            txtPrecoVenda.Location = new Point(260, 150);
            txtPrecoVenda.Name = "txtPrecoVenda";
            txtPrecoVenda.Size = new Size(120, 23);
            txtPrecoVenda.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(260, 132);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 12;
            label7.Text = "Preço Venda:";
            // 
            // txtCustoTotal
            // 
            txtCustoTotal.Location = new Point(130, 150);
            txtCustoTotal.Name = "txtCustoTotal";
            txtCustoTotal.Size = new Size(120, 23);
            txtCustoTotal.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(130, 132);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 10;
            label6.Text = "Custo Total:";
            // 
            // dtpDataProducao
            // 
            dtpDataProducao.Format = DateTimePickerFormat.Short;
            dtpDataProducao.Location = new Point(10, 100);
            dtpDataProducao.Name = "dtpDataProducao";
            dtpDataProducao.Size = new Size(200, 23);
            dtpDataProducao.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 82);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 8;
            label5.Text = "Data Produção:";
            // 
            // cmbReceita
            // 
            cmbReceita.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReceita.FormattingEnabled = true;
            cmbReceita.Location = new Point(80, 50);
            cmbReceita.Name = "cmbReceita";
            cmbReceita.Size = new Size(300, 23);
            cmbReceita.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(80, 32);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 6;
            label4.Text = "Receita:";
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
            // btnProcessarReceita
            // 
            btnProcessarReceita.Location = new Point(400, 50);
            btnProcessarReceita.Name = "btnProcessarReceita";
            btnProcessarReceita.Size = new Size(150, 30);
            btnProcessarReceita.TabIndex = 3;
            btnProcessarReceita.Text = "Processar Receita";
            btnProcessarReceita.UseVisualStyleBackColor = true;
            btnProcessarReceita.Click += btnProcessarReceita_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(200, 320);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 35);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(100, 320);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(10, 320);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(100, 35);
            btnNovo.TabIndex = 0;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(992, 368);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Itens da Produção";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            splitContainer2.SplitterDistance = 180;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox2);
            splitContainer2.Panel2.Controls.Add(groupBox3);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvItens);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(992, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingredientes Consumidos";
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Dock = DockStyle.Fill;
            dgvItens.Location = new Point(3, 19);
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.Size = new Size(986, 158);
            dgvItens.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvProdutosGerados);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(496, 184);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Produtos Gerados";
            // 
            // dgvProdutosGerados
            // 
            dgvProdutosGerados.AllowUserToAddRows = false;
            dgvProdutosGerados.AllowUserToDeleteRows = false;
            dgvProdutosGerados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutosGerados.Dock = DockStyle.Fill;
            dgvProdutosGerados.Location = new Point(3, 19);
            dgvProdutosGerados.Name = "dgvProdutosGerados";
            dgvProdutosGerados.ReadOnly = true;
            dgvProdutosGerados.Size = new Size(490, 162);
            dgvProdutosGerados.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvSobras);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(496, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(496, 184);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sobras Geradas";
            // 
            // dgvSobras
            // 
            dgvSobras.AllowUserToAddRows = false;
            dgvSobras.AllowUserToDeleteRows = false;
            dgvSobras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSobras.Dock = DockStyle.Fill;
            dgvSobras.Location = new Point(3, 19);
            dgvSobras.Name = "dgvSobras";
            dgvSobras.ReadOnly = true;
            dgvSobras.Size = new Size(490, 162);
            dgvSobras.TabIndex = 0;
            // 
            // FrmProducao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(splitContainer1);
            Name = "FrmProducao";
            Text = "Controle de Produção";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmProducao_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxPesquisa.ResumeLayout(false);
            groupBoxPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducao).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBoxCadastro.ResumeLayout(false);
            groupBoxCadastro.PerformLayout();
            tabPage2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutosGerados).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSobras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBoxPesquisa;
        private Button btnLimparPesquisa;
        private Button btnPesquisar;
        private DateTimePicker dtpPesquisaFim;
        private Label label3;
        private DateTimePicker dtpPesquisaInicio;
        private Label label2;
        private DataGridView dgvProducao;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBoxCadastro;
        private TextBox txtObservacoes;
        private Label label8;
        private TextBox txtPrecoVenda;
        private Label label7;
        private TextBox txtCustoTotal;
        private Label label6;
        private DateTimePicker dtpDataProducao;
        private Label label5;
        private ComboBox cmbReceita;
        private Label label4;
        private TextBox txtId;
        private Label labelId;
        private Button btnProcessarReceita;
        private Button btnExcluir;
        private Button btnSalvar;
        private Button btnNovo;
        private TabPage tabPage2;
        private SplitContainer splitContainer2;
        private GroupBox groupBox1;
        private DataGridView dgvItens;
        private GroupBox groupBox2;
        private DataGridView dgvProdutosGerados;
        private GroupBox groupBox3;
        private DataGridView dgvSobras;
    }
}

