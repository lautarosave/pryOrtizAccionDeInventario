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
    public partial class FrmModificar : Form
    {
        public FrmModificar()
        {
            InitializeComponent();
        }
        private void FrmModificar_Load(object sender, EventArgs e)
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

                    string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, " +
                                   "Precio = @Precio, Stock = @Stock, Categoria = @Categoria " +
                                   "WHERE Codigo = @Codigo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", int.Parse(txtCodigo.Text));
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@Precio", float.Parse(txtPrecio.Text));
                        cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("@Categoria", int.Parse(cmbCategoria.Text));

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                            MessageBox.Show("Producto modificado correctamente.");
                        else
                            MessageBox.Show("No se encontró el producto.");

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar producto: " + ex.Message);
            }
        }
    }
}
