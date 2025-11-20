using AppAcmafer.Datos;
using AppAcmafer.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppAcmafer.Vista
{
	public partial class Verificacion : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lblMensaje.Text = "";
		}
		protected void btnVerificar_Click(object sender, EventArgs e)
		{
			string codigoIngresado = txtCodigo.Text.Trim();
			string codigoSession = Session["CodigoVerificacion"] as string;
			string correoPendiente = Session["CorreoPendiente"] as string;
			DateTime? fechaCodigo = Session["FechaCodigo"] as DateTime?;

			if (codigoSession == null || correoPendiente == null || fechaCodigo == null)
			{
				lblMensaje.Text = "La sesión expiró. Por favor regístrese nuevamente.";
				return;
			}

			// Comprobamos expiración (5 minutos)
			TimeSpan diferencia = DateTime.UtcNow - fechaCodigo.Value;
			if (diferencia.TotalMinutes > 5)
			{
				// Limpiar session
				Session.Remove("CodigoVerificacion");
				Session.Remove("CorreoPendiente");
				Session.Remove("FechaCodigo");
				lblMensaje.Text = "El código expiró. Regístrese nuevamente o reenvíe el código.";
				return;
			}

			// Comparar códigos
			if (codigoIngresado == codigoSession)
			{
				// Activar cuenta en BD
				ClUsuarioD uD = new ClUsuarioD();
				int r = uD.MtActivarCuenta(correoPendiente);

				// Limpiar session
				Session.Remove("CodigoVerificacion");
				Session.Remove("CorreoPendiente");
				Session.Remove("FechaCodigo");

				if (r > 0)
				{
					// Éxito
					Response.Redirect("Login.aspx");
				}
				else
				{
					lblMensaje.Text = "Lo sentimos, no se pudo completar la verificación. Inténtelo nuevamente.";
				}
			}
			else
			{
				lblMensaje.Text = "Lo sentimos, no se pudo validar su código. Inténtelo nuevamente.";
			}
		}

		protected void btnReenviar_Click(object sender, EventArgs e)
		{
			string correoPendiente = Session["CorreoPendiente"] as string;
			if (string.IsNullOrEmpty(correoPendiente))
			{
				lblMensaje.Text = "No hay un registro pendiente. Por favor regístrese primero.";
				return;
			}

			// Generar nuevo código
			string nuevoCodigo = new Random().Next(100000, 999999).ToString();
			Session["CodigoVerificacion"] = nuevoCodigo;
			Session["FechaCodigo"] = DateTime.UtcNow;

			bool enviado = ClCorreoVerificacion.EnviarCodigo(correoPendiente, nuevoCodigo);
			if (enviado)
			{
				lblMensaje.CssClass = "text-success";
				lblMensaje.Text = "Se ha reenviado el código. Revisa tu correo.";
			}
			else
			{
				// Si falla reenviar NO eliminamos usuario (porque ya fue creado y podría estar sin verificar; opcionalmente podríamos eliminarlo)
				lblMensaje.CssClass = "text-danger";
				lblMensaje.Text = "Lo sentimos, no se pudo realizar su solicitud. Inténtelo nuevamente.";
			}
		}
	}
}