using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Modelo
{
    public class ClUsuarioM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string EstadoCuenta { get; set; }
        public string Contraseña { get; set; } 
        public ClUsuarioM() { }
    }
}