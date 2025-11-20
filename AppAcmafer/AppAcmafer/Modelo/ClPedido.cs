using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Modelo
{
	public class ClPedido:ClUsuarioM
	{
		public int idPedido { get;set;}
		public string NumPedido { get;set;}
		public DateTime fechaPedido { get;set;}
		public string EstPedido { get; set; }
		public string observaciones { get; set; }
	}
}