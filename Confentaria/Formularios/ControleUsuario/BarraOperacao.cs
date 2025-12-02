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
    public partial class BarraOperacao : UserControl
    {
        // Eventos públicos
        public event EventHandler OnAdicionar;
        public event EventHandler OnPesquisar;
        public event EventHandler OnSalvar;
        public event EventHandler OnExcluir;
        public BarraOperacao()
        {
            InitializeComponent();
            btnAdicionar.Text = "Adicionar";
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.ImageIndex = 2;
            btnSalvar.Text = "Salvar";
            btnApagar.Text = "Apagar";

            btnAdicionar.Click += (s, e) => OnAdicionar?.Invoke(this, EventArgs.Empty);
            btnPesquisar.Click += (s, e) => OnPesquisar?.Invoke(this, EventArgs.Empty);
            btnSalvar.Click += (s, e) => OnSalvar?.Invoke(this, EventArgs.Empty);
            btnApagar.Click += (s, e) => OnExcluir?.Invoke(this, EventArgs.Empty);
            flowLayoutPanel1.MaximumSize = new Size(int.MaxValue, 0);
        }

        public void MostrarBotao(bool mostrar)
        {
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            MostrarBotao(true);
        }
    }
}
