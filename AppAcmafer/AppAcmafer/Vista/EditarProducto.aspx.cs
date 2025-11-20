using AppAcmafer.Datos;
using AppAcmafer.Modelo;
using AppAcmafer.Logica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppAcmafer.Vista
{
    public partial class EditarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HabilitarCamposEdicion(false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty; 
            LimpiarCamposEdicion();         

            if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
            {
                lblMensaje.Text = "ERROR: Ingrese un ID de producto para buscar.";
                HabilitarCamposEdicion(false);
                return;
            }

            try
            {
                int idProductoAEditar = Convert.ToInt32(txtIdProducto.Text);
                CargarDatosProducto(idProductoAEditar);
            }
            catch (FormatException)
            {
                lblMensaje.Text = "ERROR: El ID debe ser un número entero válido.";
                HabilitarCamposEdicion(false);
            }
        }

       
        private void CargarDatosProducto(int idProducto)
        {
            try
            {
                ClProductoE oDatos = new ClProductoE();

                ClProductoM productoActual = oDatos.ObtenerPorId(idProducto);

                if (productoActual != null)
                {
                    txtIdEncontrado.Text = productoActual.IdProducto.ToString();
                    txtNombre.Text = productoActual.Nombre;
                    txtDescripcion.Text = productoActual.Descripcion;
                    txtPrecio.Text = productoActual.Precio.ToString();
                    txtStock.Text = productoActual.Stock.ToString();

                    lblMensaje.Text = "Producto encontrado. Listo para editar.";
                    HabilitarCamposEdicion(true);
                }
                else
                {
                    LimpiarCamposEdicion();
                    lblMensaje.Text = "ADVERTENCIA: No se encontró el producto con ese ID.";
                    HabilitarCamposEdicion(false);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"ERROR DE BÚSQUEDA/CONEXIÓN: {ex.Message}";
                HabilitarCamposEdicion(false);
            }
        }

        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClProductoM productoEditado = new ClProductoM
                {
                    IdProducto = Convert.ToInt32(txtIdEncontrado.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text, CultureInfo.InvariantCulture),
                    Stock = Convert.ToInt32(txtStock.Text)
                };

                bool usuarioActualEsEncargado = true; 

                ClProductoLogica oLogica = new ClProductoLogica();

                string resultado = oLogica.EditarProducto(productoEditado, usuarioActualEsEncargado);

                lblMensaje.Text = resultado;

            }
            catch (FormatException)
            {
                lblMensaje.Text = "ERROR: Revisar Precio y Stock. Solo se permiten números.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "ERROR INESPERADO: " + ex.Message;
            }
        }

       

        private void HabilitarCamposEdicion(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtStock.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            txtIdEncontrado.Enabled = false;
        }

        private void LimpiarCamposEdicion()
        {
            txtIdEncontrado.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
        }
    }
}