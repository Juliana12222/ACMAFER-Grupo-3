using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Datos
{
    public class ClUsuarioD
    {
        private ClConexion _conexion = new ClConexion();

        public List<ClUsuarioM> UsuariosRegistrados()
        {
            Console.WriteLine("DAL: Llamando a ClConexion y simulando resultados de la DB...");
            return new List<ClUsuarioM>
            {
                new ClUsuarioM { Id = 1, Nombre = "Ana García", Email = "ana.g@dominio.com", Rol = "Administrador", EstadoCuenta = "Activo", PasswordHash = "hash1"},
                new ClUsuarioM { Id = 2, Nombre = "Beto Pérez", Email = "beto.p@dominio.com", Rol = "Cliente", EstadoCuenta = "Activo", PasswordHash = "hash2"},
                new ClUsuarioM { Id = 3, Nombre = "Carlos Díaz", Email = "carlos.d@dominio.com", Rol = "Editor", EstadoCuenta = "Inactivo", PasswordHash = "hash3"}
            };

        }

    }
}