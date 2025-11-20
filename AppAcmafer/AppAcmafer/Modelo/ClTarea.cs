using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Modelo
{
	public class ClTarea
	{
		public int idTarea { get; set; }
		public string Titlo { get; set; }
		public string Descripcion { get; set; }
		public string Prioridad { get; set; }
		public string EstTarea { get; set; }
	}
}