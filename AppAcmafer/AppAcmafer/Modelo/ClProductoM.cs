using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Modelo
{
    public class ClProductoM: ClCategoriaM
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreación { get; set; } 
        
    }
}
