using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;


namespace pryOrtizAccionDeInventario
{
    internal class ClsConexionBD
    {
        SqlConnection coneccionBaseDatos;

        SqlCommand ComandoBaseDatos;

        string cadenaconexion = "Server=localhost;Database=Ventas2;Trusted_Connection=True;";

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
    }

    

    
}
