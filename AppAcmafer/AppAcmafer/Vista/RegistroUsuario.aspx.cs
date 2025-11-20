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
	public partial class RegistroUsuario : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lblError.Text = "";
		}
		protected void btnRegistrar_Click(object sender, EventArgs e)
		{
			// Validaciones básicas
			if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
				string.IsNullOrWhiteSpace(txtApellido.Text) ||
				string.IsNullOrWhiteSpace(txtCorreo.Text) ||
				string.IsNullOrWhiteSpace(txtContrasena.Text))
			{
				lblError.Text = "Por favor complete todos los campos obligatorios.";
				return;
			}

			string correo = txtCorreo.Text.Trim();

			ClUsuarioD uD = new ClUsuarioD();
			if (uD.MtExisteCorreo(correo))
			{
				lblError.Text = "El correo ya está registrado.";
				return;
			}

			ClUsuarioM usuario = new ClUsuarioM()
			{
				Documento = txtDocumento.Text.Trim(),
				Nombre = txtNombre.Text.Trim(),
				Apellido = txtApellido.Text.Trim(),
				Email = correo,
				Clave = ClSeguridad.Encriptar(txtContrasena.Text.Trim()),
				IdRol = 2,
				Verificado = false
			};

			// Registra el usuario (no verificado)
			int nuevoId = uD.MtRegistrarUsuario(usuario);
			if (nuevoId <= 0)
			{
				lblError.Text = "Lo sentimos, no se pudo realizar su solicitud. Inténtelo nuevamente.";
				return;
			}

			// Genera el código aleatorio de 6 dígitos
			string codigo = new Random().Next(100000, 999999).ToString();

			// Guarda en Session (no en BD) con fecha para expiración
			Session["CodigoVerificacion"] = codigo;
			Session["CorreoPendiente"] = correo;
			Session["FechaCodigo"] = DateTime.UtcNow; // UTC para evitar problemas de zona

			// Envio del código por correo
			bool enviado = ClCorreoVerificacion.EnviarCodigo(correo, codigo);

			if (!enviado)
			{
				// Si no se pudo enviar,  mostramos mensaje
				uD.MtEliminarUsuario(nuevoId);

				lblError.Text = "Lo sentimos, no se pudo realizar su solicitud. Inténtelo nuevamente.";
				return;
			}

			// Redirigir a la página de verificación (sin querystring)
			Response.Redirect("VerificarCodigo.aspx");
		}

	}
}