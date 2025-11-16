using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        public DataTable ObtenerTabla(string consultaSQL)
        {
            DataTable dtResultados = new DataTable();

            try
            {
                MtAbrirConexion();
                SqlCommand cmd = new SqlCommand(consultaSQL, oConex);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(dtResultados);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR DE CONEXIÓN O CONSULTA: " + ex.Message, ex);
            }
            finally
            {
                MtCerrarConexion();
            }

            return dtResultados;
        }
        public void MtCerrarConexion()
        {
            if (oConex.State == ConnectionState.Open)
            {
                oConex.Close();
            }
        }
    }
}
    


    

