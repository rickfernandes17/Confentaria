using Confentaria.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confentaria.Formularios
{
    public partial class FrmPesquisa : Form
    {
        private ConfentariaDbContext? _context;
        private Type? _entityType;

        public FrmPesquisa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configura o formulário para trabalhar com a entidade TEntity e o DbContext fornecido.
        /// Chame antes de mostrar o formulário para que o combo seja preenchido ao pesquisar.
        /// </summary>
        public void ConfigurarPara<TEntity>(ConfentariaDbContext context)
            where TEntity : class
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityType = typeof(TEntity);
        }
    }
}
