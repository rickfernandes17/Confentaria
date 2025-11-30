namespace Confentaria.Formularios.ControleUsuario
{
    partial class BarraOperacao
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAdicionar = new BotaoMenu();
            btnPesquisar = new BotaoMenu();
            btnSalvar = new BotaoMenu();
            btnApagar = new BotaoMenu();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btnAdicionar);
            flowLayoutPanel1.Controls.Add(btnPesquisar);
            flowLayoutPanel1.Controls.Add(btnSalvar);
            flowLayoutPanel1.Controls.Add(btnApagar);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(356, 46);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            btnAdicionar.AutoSize = true;
            btnAdicionar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdicionar.ImageIndex = 0;
            btnAdicionar.Location = new Point(3, 3);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(83, 40);
            btnAdicionar.TabIndex = 0;
            // 
            // btnPesquisar
            // 
            btnPesquisar.AutoSize = true;
            btnPesquisar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPesquisar.ImageIndex = 2;
            btnPesquisar.Location = new Point(92, 3);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(83, 40);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.AutoSize = true;
            btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvar.ImageIndex = 1;
            btnSalvar.Location = new Point(181, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(83, 40);
            btnSalvar.TabIndex = 2;
            // 
            // btnApagar
            // 
            btnApagar.AutoSize = true;
            btnApagar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnApagar.ImageIndex = 3;
            btnApagar.Location = new Point(270, 3);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(83, 40);
            btnApagar.TabIndex = 3;
            // 
            // BarraOperacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanel1);
            Name = "BarraOperacao";
            Size = new Size(356, 46);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private BotaoMenu btnAdicionar;
        private BotaoMenu btnPesquisar;
        private BotaoMenu btnSalvar;
        private BotaoMenu btnApagar;
    }
}
