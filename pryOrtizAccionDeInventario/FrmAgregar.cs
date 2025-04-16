using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryOrtizAccionDeInventario
{
    public partial class FrmAgregar : Form
    {
        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            ClsConexionBD objConectarBD = new ClsConexionBD();

            objConectarBD.ConectarBD();
            objConectarBD.Mostrar(dgvDato);
        }
    }
}
