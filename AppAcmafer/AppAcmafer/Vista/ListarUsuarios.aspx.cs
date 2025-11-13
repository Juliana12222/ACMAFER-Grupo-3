using AppAcmafer.Datos;
using AppAcmafer.Logica;
using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppAcmafer.Vista
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            // Cargar datos solo cuando la página se carga por primera vez
            if (!IsPostBack)
            {
                CargarListadoUsuarios();
            }
        }

        // Método que obtiene los datos y los enlaza al control visual
        protected void CargarListadoUsuarios()
        {
            // Instancia de la Capa de Datos
            ClUsuarioD objUsuarioD = new ClUsuarioD();

            try
            {
                // 1. Obtener la lista de usuarios desde la capa de Datos
                List<ClUsuarioM> listaUsuarios = objUsuarioD.ListarUsuarios();

                // 2. Enlazar la lista al Repeater
                rptUsuarios.DataSource = listaUsuarios;
                rptUsuarios.DataBind();

                // 3. Revisión básica: Si no hay datos, muestra alerta
                if (listaUsuarios.Count == 0)
                {
                    string script = "alert('AVISO: No se encontraron usuarios para listar.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "AlertaVacia", script, true);
                }
            }
            catch (Exception ex)
            {
                // 4. Manejo de Error básico: Alerta genérica para el usuario
                string scriptError = "alert('ERROR: Fallo al cargar los datos. Verifique la conexión a la base de datos.');";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertaError", scriptError, true);
            }
        }
    }
}