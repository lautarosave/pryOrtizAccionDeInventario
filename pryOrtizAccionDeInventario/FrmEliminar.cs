using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryOrtizAccionDeInventario
{
    public partial class FrmEliminar : Form
    {
        public FrmEliminar()
        {
            InitializeComponent();
        }

        private void Eliminar_Load(object sender, EventArgs e)
        {
            ClsConexionBD objConectarBD = new ClsConexionBD();

            objConectarBD.ConectarBD();
            objConectarBD.Mostrar(dgvDato);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ClsConexionBD conexion = new ClsConexionBD();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion.cadenaconexion))
                {
                    con.Open();

                    string query = "DELETE FROM Productos WHERE Codigo = @Codigo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", int.Parse(txtCodigo.Text));

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                            MessageBox.Show("Producto eliminado correctamente.");
                        else
                            MessageBox.Show("No se encontró el producto.");

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }
    }
}
