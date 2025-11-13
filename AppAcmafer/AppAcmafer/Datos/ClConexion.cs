using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppAcmafer.Datos
{
    public class ClConexion
    {

        SqlConnection oConex;

        public ClConexion()
        {
            oConex = new SqlConnection("Data Source=.;Initial Catalog=ProyectoACMAFER;Integrated Security=True;");
        }

        public SqlConnection MtAbrirConexion()
        {
            oConex.Open();
            return oConex;
        }

        public void MtCerrarConexion()
        {
            oConex.Close();
        }
    }
}