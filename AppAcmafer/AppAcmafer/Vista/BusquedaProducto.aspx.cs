using AppAcmafer.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppAcmafer.Vista
{
	public partial class BusquedaProducto : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
			protected void btnBuscar_Click(object sender, EventArgs e)
			{
			lblMensaje.Text = "";

			if (txtBusqueda.Text.Trim() == "")
			{
				lblMensaje.Text = "Ingrese un código o un nombre para buscar.";
				return;
			}

			ClProductoD pD = new ClProductoD();

			DataTable dt = pD.MtBuscarProducto(txtBusqueda.Text.Trim());

			if (dt.Rows.Count > 0)
			{
				gvResultados.DataSource = dt;
				gvResultados.DataBind();
			}
			else
			{
				gvResultados.DataSource = null;
				gvResultados.DataBind();
				lblMensaje.Text = "No se encontraron productos con esa búsqueda.";
			}
			}
	}
}