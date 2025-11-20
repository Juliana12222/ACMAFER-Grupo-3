using AppAcmafer.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppAcmafer.Vista
{
    public partial class ListadoProductos : System.Web.UI.Page
    {
         ClConexion Conexion;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                CargarCategorias();
                CargarProductos(0); 
            }
        }

        public void CargarCategorias()
        {
            ClConexion miConexion = new ClConexion(); 
            string consulta = "SELECT idCategoria, Nombre FROM dbo.categoria ORDER BY Nombre";

            try
            {
                DataTable tablaCategorias = miConexion.ObtenerTabla(consulta);

                ddlCategoria.DataSource = tablaCategorias;
                ddlCategoria.DataValueField = "idCategoria";
                ddlCategoria.DataTextField = "Nombre"; 
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las categorías: " + ex.Message;
                return;
            }

            ddlCategoria.Items.Insert(0, new ListItem("---CATEGORIAS ---", "0"));
        }

        public void CargarProductos(int idCategoriaSeleccionada)
        {
            ClConexion miConexion = new ClConexion(); 


            string consultaSQL = $@"
            SELECT 
                p.idProducto, 
                p.Nombre AS nombre, 
                c.Nombre AS CategoriaNombre, 
                p.PrecioUnitario AS precioUnitario, 
                p.StockActual AS stockActual 
            FROM dbo.producto p
            INNER JOIN dbo.categoria c ON p.idCategoria = c.idCategoria
            "; 

            if (idCategoriaSeleccionada > 0)
            {
                consultaSQL += $" WHERE p.idCategoria = {idCategoriaSeleccionada}";
            }

            consultaSQL += " ORDER BY p.Nombre";

            try
            {
                DataTable tablaProductos = miConexion.ObtenerTabla(consultaSQL);

                rptProductos.DataSource = tablaProductos;
                rptProductos.DataBind();

                if (tablaProductos.Rows.Count == 0 && idCategoriaSeleccionada > 0)
                {
                    lblMensaje.Text = "No se encontraron productos en la categoría seleccionada.";
                }
                else if (tablaProductos.Rows.Count == 0 && idCategoriaSeleccionada == 0)
                {
                    lblMensaje.Text = "No se encontraron productos en la base de datos.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar productos: " + ex.Message;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(ddlCategoria.SelectedValue);
            CargarProductos(idSeleccionado);
        }
    }
}