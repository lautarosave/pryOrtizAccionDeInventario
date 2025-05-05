using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data;


namespace pryOrtizAccionDeInventario
{
    internal class ClsConexionBD
    {
        SqlConnection coneccionBaseDatos;

        SqlCommand ComandoBaseDatos;

        public string cadenaconexion = "Server=pedilo;Database=Comercio;Trusted_Connection=True;";

        public string nombreBaseDeDatos;

        public void ConectarBD()
        {
            try
            {
                coneccionBaseDatos = new SqlConnection(cadenaconexion);

                nombreBaseDeDatos = coneccionBaseDatos.Database;

                coneccionBaseDatos.Open();

                MessageBox.Show("Conectado a " + nombreBaseDeDatos);
            }
            catch (Exception error)
            {
                MessageBox.Show("Tiene un errorcito - " + error.Message);
            }

        }

        public void Mostrar(DataGridView Grilla)
        {
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaconexion))
                {
                    Conexion.Open();

                    string consulta = "SELECT * From Productos";
                    using(SqlDataAdapter adaptador =  new SqlDataAdapter(consulta, Conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        Grilla.DataSource = tabla;
                    }
                }
            }
            catch (Exception error)
            {
              MessageBox.Show ("Error al mostrar datos - " + error.Message);

                coneccionBaseDatos.Close();
            }
        }
    }

    

    
}
