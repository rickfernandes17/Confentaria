namespace Confentaria.Formularios
{
    partial class FrmReceitaItem
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
            groupBox1 = new GroupBox();
            txtCustoUnitario = new TextBox();
            label3 = new Label();
            txtQuantidade = new TextBox();
            label2 = new Label();
            cmbProduto = new ComboBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnSalvar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCustoUnitario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtQuantidade);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbProduto);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Item da Receita";
            // 
            // txtCustoUnitario
            // 
            txtCustoUnitario.Location = new Point(10, 110);
            txtCustoUnitario.Name = "txtCustoUnitario";
            txtCustoUnitario.Size = new Size(150, 23);
            txtCustoUnitario.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 92);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.Text = "Custo Unitário:";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(10, 65);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(150, 23);
            txtQuantidade.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 47);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "Quantidade:";
            // 
            // cmbProduto
            // 
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduto.FormattingEnabled = true;
            cmbProduto.Location = new Point(10, 20);
            cmbProduto.Name = "cmbProduto";
            cmbProduto.Size = new Size(380, 23);
            cmbProduto.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 2);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Produto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(337, 175);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 30);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(256, 175);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 30);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FrmReceitaItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 217);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmReceitaItem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Item";
            FormClosing += FrmReceitaItem_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbProduto;
        private Label label1;
        private TextBox txtQuantidade;
        private Label label2;
        private TextBox txtCustoUnitario;
        private Label label3;
        private Button btnCancelar;
        private Button btnSalvar;
    }
}

