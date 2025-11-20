using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AppAcmafer.Logica
{
	public class ClCorreoVerificacion
	{
		// Envía el código; devuelve true si el envío fue exitoso, false si falla
		public static bool EnviarCodigo(string correoDestino, string codigo)
		{
			try
			{
				MailMessage msg = new MailMessage();
				msg.From = new MailAddress("tu_correo@gmail.com", "ACMAFER");
				msg.To.Add(correoDestino);
				msg.Subject = "Código de verificación - ACMAFER";
				msg.IsBodyHtml = false;
				msg.Body = $"Tu código de verificación es: {codigo}\n\n" +
						   "Ingresa ese código en la página de verificación para completar tu registro.";

				SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
				smtp.EnableSsl = true;
				smtp.Credentials = new NetworkCredential("tu_correo@gmail.com", "TU_CONTRASEÑA_APP");
				// Si usas cuenta corporativa u otro SMTP, cambia host/port/credenciales.

				smtp.Send(msg);
				return true;
			}
			catch (Exception)
			{
				// Podrías loguear el error aquí
				return false;
			}
		}
	}
}