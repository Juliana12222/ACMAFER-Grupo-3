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
            Conexion = new ClConexion();

            if (!IsPostBack)
            {
                CargarCategorias();
                CargarProductos(0); 
            }
        }

        public void CargarCategorias()
        {
            string consulta = "SELECT idCategoria, nombre FROM categoria ORDER BY nombre";

            try
            {
                DataTable tablaCategorias = Conexion.ObtenerTabla(consulta);

                ddlCategoria.DataSource = tablaCategorias;
                ddlCategoria.DataValueField = "idCategoria";
                ddlCategoria.DataTextField = "nombre";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las categorías. Revisa tu ClConexion: " + ex.Message;
                return;
            }

            ddlCategoria.Items.Insert(0, new ListItem("--- Mostrar Todos ---", "0"));
        }

        public void CargarProductos (int idCategoriaSeleccionada)
        {
            string consultaSQL =
                "SELECT T1.idProducto, T1.nombre, T1.precioUnitario, T1.stockActual, T2.nombre AS CategoriaNombre " +
                "FROM producto T1 INNER JOIN categoria T2 ON T1.idCategoria = T2.idCategoria";

            if (idCategoriaSeleccionada > 0)
            {
                consultaSQL += " WHERE T1.idCategoria = " + idCategoriaSeleccionada;
            }

            consultaSQL += " ORDER BY T1.nombre";

            try
            {
                DataTable tablaProductos = Conexion.ObtenerTabla(consultaSQL);

                rptProductos.DataSource = tablaProductos;
                rptProductos.DataBind();

                if (tablaProductos.Rows.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron productos en esta lista.";
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

