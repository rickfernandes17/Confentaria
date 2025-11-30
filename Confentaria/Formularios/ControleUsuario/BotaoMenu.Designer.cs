namespace Confentaria.Formularios.ControleUsuario
{
    partial class BotaoMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotaoMenu));
            button1 = new Button();
            imageListBotao = new ImageList(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageIndex = 0;
            button1.ImageList = imageListBotao;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(80, 37);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // imageListBotao
            // 
            imageListBotao.ColorDepth = ColorDepth.Depth32Bit;
            imageListBotao.ImageStream = (ImageListStreamer)resources.GetObject("imageListBotao.ImageStream");
            imageListBotao.TransparentColor = Color.Transparent;
            imageListBotao.Images.SetKeyName(0, "adicionar.png");
            imageListBotao.Images.SetKeyName(1, "salvar.png");
            imageListBotao.Images.SetKeyName(2, "pesquisar.png");
            imageListBotao.Images.SetKeyName(3, "apagar.png");
            // 
            // BotaoMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Name = "BotaoMenu";
            Size = new Size(80, 37);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ImageList imageListBotao;
    }
}
