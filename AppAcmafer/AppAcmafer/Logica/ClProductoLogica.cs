using AppAcmafer.Datos;
using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppAcmafer.Logica
{
    public class ClProductoLogica
    {
         ClProductoE oProductoDatos = new ClProductoE();
        public string EditarProducto(ClProductoM oProductoAEditar, bool esEncargado)
        {
            if (esEncargado == false)
            {
                return "PERMISO DENEGADO: Solo un Encargado puede realizar la edición del producto.";
            }

            if (string.IsNullOrWhiteSpace(oProductoAEditar.Nombre) || oProductoAEditar.IdProducto <= 0)
            {
                return "ERROR: El producto o el nombre no son válidos.";
            }

            try
            {
                bool exito = oProductoDatos.ActualizarProducto(oProductoAEditar);

                if (exito)
                {
                    return "ÉXITO: El producto se ha actualizado correctamente.";
                }
                else
                {
                    return "ADVERTENCIA: No se pudo actualizar. ID no encontrado.";
                }
            }
            catch (Exception ex)
            {
                return $"ERROR DE SISTEMA AL GUARDAR: {ex.Message}";
            }
        }
    }
}

