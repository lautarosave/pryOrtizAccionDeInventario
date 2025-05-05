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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ClsConexionBD conexion = new ClsConexionBD();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion.cadenaconexion))
                {
                    con.Open();

                    string query = "INSERT INTO Inventario (Codigo, Nombre, Descripcion, Precio, Stock, Categoria) " +
                           "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Categoria)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.Int) { Value = int.Parse(txtCodigo.Text) });
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = txtNombre.Text });
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = txtDescripcion.Text });
                    cmd.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = decimal.Parse(txtPrecio.Text)
                    });
                    cmd.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = int.Parse(txtStock.Text) });
                    cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 50) { Value = cmbCategoria.SelectedItem.ToString() });

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Datos guardados correctamente.");
            }   }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
