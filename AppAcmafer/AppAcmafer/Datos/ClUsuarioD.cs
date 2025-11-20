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

		public bool MtExisteCorreo(string email)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				string sql = "SELECT COUNT(1) FROM usuario WHERE email = @email";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@email", email);
					con.Open();
					int count = Convert.ToInt32(cmd.ExecuteScalar());
					return count > 0;
				}
			}
		}

		public int MtRegistrarUsuario(ClUsuarioM usuario)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				string sql = @"
                    INSERT INTO Usuario (Documento, nombre, apellido, email, clave, idRol, verificado, fechaRegistro)
                    VALUES (@documento, @nombre, @apellido, @email, @clave, @rol, 0, GETDATE());
                    SELECT SCOPE_IDENTITY();";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@Documento", (object)usuario.Documento ?? DBNull.Value);
					cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
					cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
					cmd.Parameters.AddWithValue("@email", usuario.Email);
					cmd.Parameters.AddWithValue("@clave", usuario.Clave);
					cmd.Parameters.AddWithValue("@rol", usuario.Rol);

					con.Open();
					object res = cmd.ExecuteScalar();
					int id = res != null ? Convert.ToInt32(res) : 0;
					return id;
				}
			}
		}

		public int MtActivarCuenta(string email)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				string sql = "UPDATE usuario SET verificado = 1 WHERE email = @email";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@email", email);
					con.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}

		public int MtEliminarUsuario(int idUsuario)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				string sql = "DELETE FROM usuario WHERE idUsuario = @idUsuario";
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
					con.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}

		public int MtValidarLogin(string correo, string contraseña)
		{
			string consulta = "SELECT COUNT(*) FROM Usuario WHERE Correo = @Correo AND Contrasena = @Contrasena";

			using (SqlConnection con = new SqlConnection())
			{
				using (SqlCommand cmd = new SqlCommand(consulta, con))
				{
					cmd.Parameters.AddWithValue("@Correo", correo);
					cmd.Parameters.AddWithValue("@Contrasena", contraseña);

					con.Open();
					int existe = Convert.ToInt32(cmd.ExecuteScalar());
					return existe; // 1 = OK, 0 = error
				}
			}
		}

		public int MtObtenerIdUsuario(string correo)
		{
			string consulta = "SELECT IdUsuario FROM Usuario WHERE Correo = @Correo";

			using (SqlConnection con = new SqlConnection())
			{
				using (SqlCommand cmd = new SqlCommand(consulta, con))
				{
					cmd.Parameters.AddWithValue("@Correo", correo);

					con.Open();
					object resultado = cmd.ExecuteScalar();

					return resultado != null ? Convert.ToInt32(resultado) : 0;
				}
			}
		}


		public List<ClUsuarioM> ListarUsuarios()
        {
            List<ClUsuarioM> listaUsuarios = new List<ClUsuarioM>();

            string query = "SELECT u.idUsuario, u.documento, u.nombre, u.apellido, u.email, c.celular,cl.clave,e.estado, r.idRol, u.estado " +
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
                        // ... (Campos adicionales que necesites)
                        IdRol = Convert.ToInt32(reader["rol"]),
                        // Nota: Asegúrate de que los alias 'rol', 'estado' en la consulta sean correctos.
                        Estado = reader["estado"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
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

        // Aquí irían los métodos: GuardarUsuario(), EditarUsuario(), EliminarUsuario(), etc.
    }

}
