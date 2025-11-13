using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppAcmafer.Datos
{
    public class ClUsuarioD
    {
         ClConexion oConexion = new ClConexion();

        public List<ClUsuarioM> ListarUsuarios()
        {
            List<ClUsuarioM> listaUsuarios = new List<ClUsuarioM>();

            string query = "SELECT u.idUsuario, u.documento, u.nombre, u.apellido, u.email, r.rol, u.estado " +
                           "FROM [dbo].[usuario] u INNER JOIN [dbo].[rol] r ON u.idRol = r.idRol " +
                           "ORDER BY u.idUsuario ASC";

            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                SqlConnection oConex = oConexion.MtAbrirConexion();
                command = new SqlCommand(query, oConex);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listaUsuarios.Add(new ClUsuarioM()
                    {
                        IdUsuario = Convert.ToInt32(reader["idUsuario"]),
                        Documento = reader["documento"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Email = reader["email"].ToString(),
                        Rol = reader["rol"].ToString(),
                        Estado = reader["estado"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Capa de Datos: " + ex.Message);
                listaUsuarios = new List<ClUsuarioM>();
            }
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                oConexion.MtCerrarConexion();
            }
            return listaUsuarios;
        }
    }
}
