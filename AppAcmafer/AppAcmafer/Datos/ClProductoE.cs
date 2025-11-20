using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppAcmafer.Datos
{
    public class ClProductoE
    {
        private const string SQL_SELECT_BY_ID =
            "SELECT IdProducto, Nombre, Descripcion, Precio, Stock FROM Productos WHERE IdProducto = @Id";

        private const string SQL_UPDATE =
            "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock WHERE IdProducto = @Id";


        public ClProductoM ObtenerPorId(int idProducto)
        {
            ClProductoM producto = null;
            ClConexion objConexion = new ClConexion(); 
            SqlConnection conexion = null; 

            try
            {
                conexion = objConexion.MtAbrirConexion(); 
                if (conexion == null) return null;

                using (SqlCommand comando = new SqlCommand(SQL_SELECT_BY_ID, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", idProducto);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            producto = new ClProductoM();

                            producto.IdProducto = (int)reader["IdProducto"];
                            producto.Nombre = reader["Nombre"].ToString();
                            producto.Descripcion = reader["Descripcion"].ToString();
                            producto.Precio = (decimal)reader["Precio"];
                            producto.Stock = (int)reader["Stock"];
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine("Error al obtener producto (ClProductoE): " + ex.Message);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return producto;
        }

        public bool ActualizarProducto(ClProductoM producto)
        {
            ClConexion objConexion = new ClConexion(); 

           
            using (SqlConnection conexion = objConexion.MtAbrirConexion()) 
            {
                using (SqlCommand comando = new SqlCommand(SQL_UPDATE, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@Id", producto.IdProducto);

                    try
                    {
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas == 1; 
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al ejecutar UPDATE en la Base de Datos.", ex);
                    }
                }
            }
        }
    }
}


