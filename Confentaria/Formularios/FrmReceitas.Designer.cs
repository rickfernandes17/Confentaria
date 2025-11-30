namespace Confentaria.Formularios
{
    partial class FrmReceitas
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
            dgvReceitas = new DataGridView();
            groupBoxPesquisa = new GroupBox();
            btnLimparPesquisa = new Button();
            btnPesquisar = new Button();
            txtPesquisaNome = new TextBox();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBoxCadastro = new GroupBox();
            txtObservacoes = new TextBox();
            label8 = new Label();
            txtPrecoVendaSugerido = new TextBox();
            label7 = new Label();
            txtCustoTotal = new TextBox();
            label6 = new Label();
            txtDescricao = new TextBox();
            label5 = new Label();
            txtNome = new TextBox();
            labelNome = new Label();
            txtId = new TextBox();
            labelId = new Label();
            btnExcluir = new Button();
            btnSalvar = new Button();
            btnNovo = new Button();
            tabPage2 = new TabPage();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            btnAdicionarItem = new Button();
            dgvItens = new DataGridView();
            groupBox2 = new GroupBox();
            btnAdicionarProdutoGerado = new Button();
            dgvProdutosGerados = new DataGridView();
            groupBox3 = new GroupBox();
            btnAdicionarSobra = new Button();
            dgvSobras = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceitas).BeginInit();
            groupBoxPesquisa.SuspendLayout();
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
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvReceitas);
            splitContainer1.Panel1.Controls.Add(groupBoxPesquisa);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1000, 700);
            splitContainer1.SplitterDistance = 319;
            splitContainer1.TabIndex = 0;
            // 
            // dgvReceitas
            // 
            dgvReceitas.AllowUserToAddRows = false;
            dgvReceitas.AllowUserToDeleteRows = false;
            dgvReceitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReceitas.Dock = DockStyle.Fill;
            dgvReceitas.Location = new Point(0, 80);
            dgvReceitas.Name = "dgvReceitas";
            dgvReceitas.ReadOnly = true;
            dgvReceitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceitas.Size = new Size(1000, 239);
            dgvReceitas.TabIndex = 0;
            dgvReceitas.CellContentClick += dgvReceitas_CellContentClick;
            dgvReceitas.SelectionChanged += dgvReceitas_SelectionChanged;
            // 
            // groupBoxPesquisa
            // 
            groupBoxPesquisa.Controls.Add(btnLimparPesquisa);
            groupBoxPesquisa.Controls.Add(btnPesquisar);
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
            btnLimparPesquisa.Location = new Point(310, 44);
            btnLimparPesquisa.Name = "btnLimparPesquisa";
            btnLimparPesquisa.Size = new Size(100, 25);
            btnLimparPesquisa.TabIndex = 3;
            btnLimparPesquisa.Text = "Limpar";
            btnLimparPesquisa.UseVisualStyleBackColor = true;
            btnLimparPesquisa.Click += btnLimparPesquisa_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(210, 44);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(100, 25);
            btnPesquisar.TabIndex = 2;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 377);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBoxCadastro);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(992, 349);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados da Receita";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxCadastro
            // 
            groupBoxCadastro.Controls.Add(txtObservacoes);
            groupBoxCadastro.Controls.Add(label8);
            groupBoxCadastro.Controls.Add(txtPrecoVendaSugerido);
            groupBoxCadastro.Controls.Add(label7);
            groupBoxCadastro.Controls.Add(txtCustoTotal);
            groupBoxCadastro.Controls.Add(label6);
            groupBoxCadastro.Controls.Add(txtDescricao);
            groupBoxCadastro.Controls.Add(label5);
            groupBoxCadastro.Controls.Add(txtNome);
            groupBoxCadastro.Controls.Add(labelNome);
            groupBoxCadastro.Controls.Add(txtId);
            groupBoxCadastro.Controls.Add(labelId);
            groupBoxCadastro.Controls.Add(btnExcluir);
            groupBoxCadastro.Controls.Add(btnSalvar);
            groupBoxCadastro.Controls.Add(btnNovo);
            groupBoxCadastro.Dock = DockStyle.Fill;
            groupBoxCadastro.Location = new Point(3, 3);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(986, 343);
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
            txtObservacoes.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 182);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 13;
            label8.Text = "Observações:";
            // 
            // txtPrecoVendaSugerido
            // 
            txtPrecoVendaSugerido.Location = new Point(260, 150);
            txtPrecoVendaSugerido.Name = "txtPrecoVendaSugerido";
            txtPrecoVendaSugerido.Size = new Size(120, 23);
            txtPrecoVendaSugerido.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(260, 132);
            label7.Name = "label7";
            label7.Size = new Size(125, 15);
            label7.TabIndex = 11;
            label7.Text = "Preço Venda Sugerido:";
            // 
            // txtCustoTotal
            // 
            txtCustoTotal.Location = new Point(130, 150);
            txtCustoTotal.Name = "txtCustoTotal";
            txtCustoTotal.Size = new Size(120, 23);
            txtCustoTotal.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(130, 132);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 9;
            label6.Text = "Custo Total:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(10, 100);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(500, 30);
            txtDescricao.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 82);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 7;
            label5.Text = "Descrição:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(80, 50);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(300, 23);
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
            tabPage2.Size = new Size(992, 349);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Itens da Receita";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = Color.RosyBrown;
            splitContainer2.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = Color.Red;
            splitContainer2.Panel2.Controls.Add(groupBox2);
            splitContainer2.Panel2.Controls.Add(groupBox3);
            splitContainer2.Size = new Size(986, 343);
            splitContainer2.SplitterDistance = 243;
            splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdicionarItem);
            groupBox1.Controls.Add(dgvItens);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(986, 243);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingredientes";
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.Location = new Point(10, 20);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.Size = new Size(120, 25);
            btnAdicionarItem.TabIndex = 1;
            btnAdicionarItem.Text = "Adicionar Ingrediente";
            btnAdicionarItem.UseVisualStyleBackColor = true;
            btnAdicionarItem.Click += btnAdicionarItem_Click;
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
            dgvItens.Size = new Size(980, 221);
            dgvItens.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAdicionarProdutoGerado);
            groupBox2.Controls.Add(dgvProdutosGerados);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(496, 96);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Produtos Gerados";
            // 
            // btnAdicionarProdutoGerado
            // 
            btnAdicionarProdutoGerado.Location = new Point(10, 20);
            btnAdicionarProdutoGerado.Name = "btnAdicionarProdutoGerado";
            btnAdicionarProdutoGerado.Size = new Size(150, 25);
            btnAdicionarProdutoGerado.TabIndex = 1;
            btnAdicionarProdutoGerado.Text = "Adicionar Produto";
            btnAdicionarProdutoGerado.UseVisualStyleBackColor = true;
            btnAdicionarProdutoGerado.Click += btnAdicionarProdutoGerado_Click;
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
            dgvProdutosGerados.Size = new Size(490, 74);
            dgvProdutosGerados.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnAdicionarSobra);
            groupBox3.Controls.Add(dgvSobras);
            groupBox3.Dock = DockStyle.Right;
            groupBox3.Location = new Point(514, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(472, 96);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sobras";
            // 
            // btnAdicionarSobra
            // 
            btnAdicionarSobra.Location = new Point(10, 20);
            btnAdicionarSobra.Name = "btnAdicionarSobra";
            btnAdicionarSobra.Size = new Size(120, 25);
            btnAdicionarSobra.TabIndex = 1;
            btnAdicionarSobra.Text = "Adicionar Sobra";
            btnAdicionarSobra.UseVisualStyleBackColor = true;
            btnAdicionarSobra.Click += btnAdicionarSobra_Click;
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
            dgvSobras.Size = new Size(466, 74);
            dgvSobras.TabIndex = 0;
            // 
            // FrmReceitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(splitContainer1);
            Name = "FrmReceitas";
            Text = "Cadastro de Receitas";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmReceitas_FormClosing;
            Load += FrmReceitas_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceitas).EndInit();
            groupBoxPesquisa.ResumeLayout(false);
            groupBoxPesquisa.PerformLayout();
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
        private TextBox txtPesquisaNome;
        private Label label2;
        private DataGridView dgvReceitas;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBoxCadastro;
        private TextBox txtObservacoes;
        private Label label8;
        private TextBox txtPrecoVendaSugerido;
        private Label label7;
        private TextBox txtCustoTotal;
        private Label label6;
        private TextBox txtDescricao;
        private Label label5;
        private TextBox txtNome;
        private Label labelNome;
        private TextBox txtId;
        private Label labelId;
        private Button btnExcluir;
        private Button btnSalvar;
        private Button btnNovo;
        private TabPage tabPage2;
        private SplitContainer splitContainer2;
        private GroupBox groupBox1;
        private Button btnAdicionarItem;
        private DataGridView dgvItens;
        private GroupBox groupBox2;
        private Button btnAdicionarProdutoGerado;
        private DataGridView dgvProdutosGerados;
        private GroupBox groupBox3;
        private Button btnAdicionarSobra;
        private DataGridView dgvSobras;
    }
}

