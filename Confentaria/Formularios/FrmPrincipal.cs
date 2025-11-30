using Confentaria.Formularios;

namespace Confentaria
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmProdutos>();
        }

        private void receitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmReceitas>();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmFornecedores>();
        }

        private void produçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmProducao>();
        }

        private void notasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmNotasFiscais>();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            // Fecha todos os formulários MDI abertos
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }

            // Abre o novo formulário
            T frm = new T
            {
                MdiParent = this
            };
            frm.Show();
        }
    }
}
