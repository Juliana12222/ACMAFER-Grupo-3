using AppAcmafer.Datos;
using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppAcmafer.Vista
{
	public partial class AñadirProducto : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		
		}
		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			lblMensaje.Text = "";

			if (txtCodigo.Text == "" || txtNombre.Text == "" || txtCantidad.Text == "" || txtPrecio.Text == "")
			{
				lblMensaje.Text = "Complete todos los campos obligatorios.";
				return;
			}

			ClProductoD pD = new ClProductoD();

			// validar código repetido
			if (pD.MtExisteCodigo(txtCodigo.Text.Trim()))
			{
				lblMensaje.Text = "El código del producto ya existe.";
				return;
			}

			ClProductoM producto = new ClProductoM()
			{
				Codigo = txtCodigo.Text.Trim(),
				Nombre = txtNombre.Text.Trim(),
				Descripcion = txtDescripcion.Text.Trim(),
				Stock = int.Parse(txtCantidad.Text),
				Precio = decimal.Parse(txtPrecio.Text),
				Estado = ddlEstado.SelectedValue
			};

			int result = pD.MtRegistrarProducto(producto);

			if (result > 0)
			{
				lblMensaje.CssClass = "text-success";
				lblMensaje.Text = "Producto registrado correctamente.";

				// limpiar campos
				txtCodigo.Text = "";
				txtNombre.Text = "";
				txtDescripcion.Text = "";
				txtCantidad.Text = "";
				txtPrecio.Text = "";
			}
			else
			{
				lblMensaje.Text = "Ocurrió un error al registrar el producto.";
			}
		}
	}
}
