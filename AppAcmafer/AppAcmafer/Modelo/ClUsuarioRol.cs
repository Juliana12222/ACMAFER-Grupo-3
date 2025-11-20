using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Modelo
{
	public class ClUsuarioRol
	{
		public int IdUsuario { get; set; }
		public int IdRol { get; set; }

		public ClUsuarioM usuario {get; set;}
		public ClRol estado {get; set;}
}
}