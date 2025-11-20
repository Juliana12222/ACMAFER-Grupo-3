using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppAcmafer.Datos
{
    public class ClProductoD
    {
         ClConexion oConexion = new ClConexion();


		public int MtRegistrarProducto(ClProductoM producto)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
					"INSERT INTO producto (codigo, nombre, descripcion, stockActual, precioUnitario, fechaCreacion, estado) VALUES (@Codigo, @Nombre, @Descripcion, @Cantidad, @Precio, @FechaCreacion, @Estado)",
					con
				);

				cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
				cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
				cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
				cmd.Parameters.AddWithValue("@Cantidad", producto.Stock);
				cmd.Parameters.AddWithValue("@Precio", producto.Precio);
				cmd.Parameters.AddWithValue("@FechaCreacion", producto.FechaCreación);
				cmd.Parameters.AddWithValue("@Estado", producto.Estado);

				return cmd.ExecuteNonQuery();
			}
		}

		// Validar que no exista código repetido
		public bool MtExisteCodigo(string codigo)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
					"SELECT COUNT(*) FROM producto WHERE Codigo = @Codigo",
					con
				);

				cmd.Parameters.AddWithValue("@Codigo", codigo);

				return (int)cmd.ExecuteScalar() > 0;
			}
		}


		public DataTable MtBuscarProducto(string busqueda)
		{
			using (SqlConnection con = oConexion.MtAbrirConexion())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
					"SELECT * FROM producto WHERE codigo LIKE @Busqueda OR Nombre LIKE @Busqueda",
					con
				);

				cmd.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				return dt;
			}
		}

		public List<ClCategoriaM> ListarCategoriasDB()
        {
            List<ClCategoriaM> lista = new List<ClCategoriaM>();
            string query = "SELECT idCategoria, nombre FROM categoria WHERE estado = 'Activo'";

            try
            {
                using (SqlConnection oConex = oConexion.MtAbrirConexion())
                {
                    SqlCommand command = new SqlCommand(query, oConex);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ClCategoriaM()
                            {
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                nombre = reader["nombre"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al listar categorías: " + ex.Message);
            }
            finally
            {
                oConexion.MtCerrarConexion();
            }
            return lista;
        }

        
        public List<ClProductoM> ListarProductosPorCategoriaDB(int idCategoria)
        {
            List<ClProductoM> lista = new List<ClProductoM>();
            string query = "SELECT p.idProducto, p.nombre, p.descripcion, p.precio, p.stock, c.nombre AS Categoria " +
                           "FROM producto p INNER JOIN categoria c ON p.idCategoria = c.idCategoria " +
                           "WHERE (@IdCategoria = 0 OR p.idCategoria = @IdCategoria) AND p.estado = 'Activo'";

            try
            {
                using (SqlConnection oConex = oConexion.MtAbrirConexion())
                {
                    SqlCommand command = new SqlCommand(query, oConex);
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria); 

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ClProductoM()
                            {
                                IdProducto = Convert.ToInt32(reader["idProducto"]),
                                Nombre = reader["nombre"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                nombre = reader["Categoria"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            finally
            {
                oConexion.MtCerrarConexion();
            }
            return lista;
        }
    }
}