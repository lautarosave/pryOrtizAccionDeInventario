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
        ClsConexionBD objetobjConectarBD = new ClsConexionBD();
        private int codigoSeleccionado = -1;
        private void FrmModificar_Load(object sender, EventArgs e)
        {
            ClsConexionBD objConectarBD = new ClsConexionBD();

            objConectarBD.ConectarBD();
            objConectarBD.Mostrar(dgvDato);

            DataTable categorias = objConectarBD.ObtenerCategorias();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";  // Lo que se muestra
            cmbCategoria.ValueMember = "Id";        // El valor real (por ejemplo, para guardar en DB)
            cmbCategoria.SelectedIndex = -1;        // Opcional, para que no haya nada seleccionado al inicio
            int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (codigoSeleccionado == -1)
            {
                MessageBox.Show("Seleccioná un producto para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio = Convert.ToInt32(txtPrecio.Text);
            int stock = Convert.ToInt32(txtStock.Text);
            string categoriaId = cmbCategoria.SelectedValue.ToString();

            // Llamar al método que actualiza en la base de datos
            objetobjConectarBD.ModificarProducto(
                codigoSeleccionado,
                nombre,
                descripcion,
                precio,
                stock,
                categoriaId
            );

            // Actualizar la grilla
            dgvDato.DataSource = objetobjConectarBD.ObtenerDatosTabla("Contactos");

            // Limpiar los controles
            codigoSeleccionado = -1;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
        }

        private void dgvDato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnModificar.Enabled = true;
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDato.Rows[e.RowIndex];

                // Guardamos el Código del producto para luego usarlo en la modificación
                codigoSeleccionado = Convert.ToInt32(fila.Cells["Codigo"].Value);

                // Cargamos los valores en los controles
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
                cmbCategoria.SelectedValue = fila.Cells["CategoriaId"].Value;
            }
        }
    }
}
