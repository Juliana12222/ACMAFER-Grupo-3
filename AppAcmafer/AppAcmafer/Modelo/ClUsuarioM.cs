using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Modelo
{
    public class ClUsuarioM:ClRol
    {
            public int IdUsuario { get; set; }
            public string Documento { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public string Celular { get; set; }
            public string Estado { get; set; }
            public string Clave { get; set; }
		    public bool Verificado { get; set; }
	}
    }