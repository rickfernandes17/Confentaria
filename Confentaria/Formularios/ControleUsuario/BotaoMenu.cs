using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confentaria.Formularios.ControleUsuario
{
    public partial class BotaoMenu : UserControl
    {
       override public string Text { 
            get => button1.Text;
            set { 
                button1.Text = value;
                AjustarLargura();
            }
        }
        public int ImageIndex { get => button1.ImageIndex; set => button1.ImageIndex = value; }
        public BotaoMenu()
        {
            InitializeComponent();

            // Propaga o clique do botão interno para o UserControl
            button1.Click += (s, e) => this.OnClick(e);

            // Auto size do usercontrol
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void AjustarLargura()
        {
            if (string.IsNullOrWhiteSpace(button1.Text))
                return;

            // Largura necessária para o texto
            var tamanhoTexto = TextRenderer.MeasureText(button1.Text, button1.Font);

            int larguraImagem = button1.ImageList != null ? 24 : 0;  // largura da imagem (ajuste se necessário)
            int margem = 3;  // espaço interno do botão

            int novaLargura = tamanhoTexto.Width + larguraImagem + margem;

            // Define largura mínima se quiser
            if (novaLargura < 20)
                novaLargura = 20;

            //Define largura maxima se quiser
            if (novaLargura > 160)
                novaLargura = 160;

            button1.Width = novaLargura;
            this.Width = novaLargura; // UserControl acompanha
        }
    }
}
