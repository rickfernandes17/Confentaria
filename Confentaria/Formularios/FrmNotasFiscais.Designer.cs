namespace Confentaria.Formularios
{
    partial class FrmNotasFiscais
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
            txtPesquisaNumero = new TextBox();
            label1 = new Label();
            dgvNotasFiscais = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBoxCadastro = new GroupBox();
            txtObservacoes = new TextBox();
            label9 = new Label();
            btnProcessarUrl = new Button();
            txtValorTotal = new TextBox();
            label8 = new Label();
            txtUrl = new TextBox();
            label7 = new Label();
            dtpDataEmissao = new DateTimePicker();
            label6 = new Label();
            txtSerie = new TextBox();
            label5 = new Label();
            txtNumero = new TextBox();
            label4 = new Label();
            cmbFornecedor = new ComboBox();
            labelFornecedor = new Label();
            txtId = new TextBox();
            labelId = new Label();
            btnExcluir = new Button();
            btnSalvar = new Button();
            btnNovo = new Button();
            tabPage2 = new TabPage();
            dgvItens = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotasFiscais).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBoxCadastro.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(dgvNotasFiscais);
            splitContainer1.Panel1.Controls.Add(groupBoxPesquisa);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1000, 700);
            splitContainer1.SplitterDistance = 497;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxPesquisa
            // 
            groupBoxPesquisa.Controls.Add(btnLimparPesquisa);
            groupBoxPesquisa.Controls.Add(btnPesquisar);
            groupBoxPesquisa.Controls.Add(dtpPesquisaFim);
            groupBoxPesquisa.Controls.Add(label3);
            groupBoxPesquisa.Controls.Add(dtpPesquisaInicio);
            groupBoxPesquisa.Controls.Add(label2);
            groupBoxPesquisa.Controls.Add(txtPesquisaNumero);
            groupBoxPesquisa.Controls.Add(label1);
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
            btnLimparPesquisa.Location = new Point(520, 45);
            btnLimparPesquisa.Name = "btnLimparPesquisa";
            btnLimparPesquisa.Size = new Size(100, 25);
            btnLimparPesquisa.TabIndex = 7;
            btnLimparPesquisa.Text = "Limpar";
            btnLimparPesquisa.UseVisualStyleBackColor = true;
            btnLimparPesquisa.Click += btnLimparPesquisa_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(410, 45);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(100, 25);
            btnPesquisar.TabIndex = 6;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // dtpPesquisaFim
            // 
            dtpPesquisaFim.Format = DateTimePickerFormat.Short;
            dtpPesquisaFim.Location = new Point(330, 45);
            dtpPesquisaFim.Name = "dtpPesquisaFim";
            dtpPesquisaFim.Size = new Size(70, 23);
            dtpPesquisaFim.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 27);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Data Fim:";
            // 
            // dtpPesquisaInicio
            // 
            dtpPesquisaInicio.Format = DateTimePickerFormat.Short;
            dtpPesquisaInicio.Location = new Point(230, 45);
            dtpPesquisaInicio.Name = "dtpPesquisaInicio";
            dtpPesquisaInicio.Size = new Size(90, 23);
            dtpPesquisaInicio.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 27);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 2;
            label2.Text = "Data Início:";
            // 
            // txtPesquisaNumero
            // 
            txtPesquisaNumero.Location = new Point(10, 45);
            txtPesquisaNumero.Name = "txtPesquisaNumero";
            txtPesquisaNumero.Size = new Size(200, 23);
            txtPesquisaNumero.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 27);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Número:";
            // 
            // dgvNotasFiscais
            // 
            dgvNotasFiscais.AllowUserToAddRows = false;
            dgvNotasFiscais.AllowUserToDeleteRows = false;
            dgvNotasFiscais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotasFiscais.Dock = DockStyle.Fill;
            dgvNotasFiscais.Location = new Point(0, 80);
            dgvNotasFiscais.Name = "dgvNotasFiscais";
            dgvNotasFiscais.ReadOnly = true;
            dgvNotasFiscais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotasFiscais.Size = new Size(1000, 417);
            dgvNotasFiscais.TabIndex = 0;
            dgvNotasFiscais.SelectionChanged += dgvNotasFiscais_SelectionChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 199);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBoxCadastro);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(992, 171);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados da Nota Fiscal";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxCadastro
            // 
            groupBoxCadastro.Controls.Add(txtObservacoes);
            groupBoxCadastro.Controls.Add(label9);
            groupBoxCadastro.Controls.Add(btnProcessarUrl);
            groupBoxCadastro.Controls.Add(txtValorTotal);
            groupBoxCadastro.Controls.Add(label8);
            groupBoxCadastro.Controls.Add(txtUrl);
            groupBoxCadastro.Controls.Add(label7);
            groupBoxCadastro.Controls.Add(dtpDataEmissao);
            groupBoxCadastro.Controls.Add(label6);
            groupBoxCadastro.Controls.Add(txtSerie);
            groupBoxCadastro.Controls.Add(label5);
            groupBoxCadastro.Controls.Add(txtNumero);
            groupBoxCadastro.Controls.Add(label4);
            groupBoxCadastro.Controls.Add(cmbFornecedor);
            groupBoxCadastro.Controls.Add(labelFornecedor);
            groupBoxCadastro.Controls.Add(txtId);
            groupBoxCadastro.Controls.Add(labelId);
            groupBoxCadastro.Controls.Add(btnExcluir);
            groupBoxCadastro.Controls.Add(btnSalvar);
            groupBoxCadastro.Controls.Add(btnNovo);
            groupBoxCadastro.Dock = DockStyle.Fill;
            groupBoxCadastro.Location = new Point(3, 3);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(986, 165);
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
            txtObservacoes.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 182);
            label9.Name = "label9";
            label9.Size = new Size(77, 15);
            label9.TabIndex = 19;
            label9.Text = "Observações:";
            // 
            // btnProcessarUrl
            // 
            btnProcessarUrl.Location = new Point(400, 150);
            btnProcessarUrl.Name = "btnProcessarUrl";
            btnProcessarUrl.Size = new Size(150, 30);
            btnProcessarUrl.TabIndex = 18;
            btnProcessarUrl.Text = "Processar URL";
            btnProcessarUrl.UseVisualStyleBackColor = true;
            btnProcessarUrl.Click += btnProcessarUrl_Click;
            // 
            // txtValorTotal
            // 
            txtValorTotal.Location = new Point(260, 150);
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.Size = new Size(120, 23);
            txtValorTotal.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(260, 132);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 16;
            label8.Text = "Valor Total:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(10, 150);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(240, 23);
            txtUrl.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 132);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 14;
            label7.Text = "URL:";
            // 
            // dtpDataEmissao
            // 
            dtpDataEmissao.Format = DateTimePickerFormat.Short;
            dtpDataEmissao.Location = new Point(230, 100);
            dtpDataEmissao.Name = "dtpDataEmissao";
            dtpDataEmissao.Size = new Size(200, 23);
            dtpDataEmissao.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(230, 82);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 12;
            label6.Text = "Data Emissão:";
            // 
            // txtSerie
            // 
            txtSerie.Location = new Point(130, 100);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(90, 23);
            txtSerie.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(130, 82);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 10;
            label5.Text = "Série:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(10, 100);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(110, 23);
            txtNumero.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 82);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 8;
            label4.Text = "Número:";
            // 
            // cmbFornecedor
            // 
            cmbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFornecedor.FormattingEnabled = true;
            cmbFornecedor.Location = new Point(80, 50);
            cmbFornecedor.Name = "cmbFornecedor";
            cmbFornecedor.Size = new Size(300, 23);
            cmbFornecedor.TabIndex = 7;
            // 
            // labelFornecedor
            // 
            labelFornecedor.AutoSize = true;
            labelFornecedor.Location = new Point(80, 32);
            labelFornecedor.Name = "labelFornecedor";
            labelFornecedor.Size = new Size(70, 15);
            labelFornecedor.TabIndex = 6;
            labelFornecedor.Text = "Fornecedor:";
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
            tabPage2.Controls.Add(dgvItens);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(992, 368);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Itens da Nota Fiscal";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Dock = DockStyle.Fill;
            dgvItens.Location = new Point(3, 3);
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.Size = new Size(986, 362);
            dgvItens.TabIndex = 0;
            // 
            // FrmNotasFiscais
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(splitContainer1);
            Name = "FrmNotasFiscais";
            Text = "Cadastro de Notas Fiscais";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmNotasFiscais_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxPesquisa.ResumeLayout(false);
            groupBoxPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotasFiscais).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBoxCadastro.ResumeLayout(false);
            groupBoxCadastro.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
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
        private TextBox txtPesquisaNumero;
        private Label label1;
        private DataGridView dgvNotasFiscais;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBoxCadastro;
        private TextBox txtObservacoes;
        private Label label9;
        private Button btnProcessarUrl;
        private TextBox txtValorTotal;
        private Label label8;
        private TextBox txtUrl;
        private Label label7;
        private DateTimePicker dtpDataEmissao;
        private Label label6;
        private TextBox txtSerie;
        private Label label5;
        private TextBox txtNumero;
        private Label label4;
        private ComboBox cmbFornecedor;
        private Label labelFornecedor;
        private TextBox txtId;
        private Label labelId;
        private Button btnExcluir;
        private Button btnSalvar;
        private Button btnNovo;
        private TabPage tabPage2;
        private DataGridView dgvItens;
    }
}

