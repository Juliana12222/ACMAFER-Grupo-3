using AppAcmafer.Datos;
using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Logica
{
    public class ClUsuarioL
    {
         ClUsuarioD ClUsuarioD = new ClUsuarioD();

        public List<ClUsuarioM> ListarUsuariosRegistrados(string rolSolicitante)
        {
            if (rolSolicitante != "Administrador")
            {
                Console.WriteLine("Acceso denegado. Se requiere rol de Administrador.");
                return null;
            }

            var usuariosDB = ClUsuarioD.UsuariosRegistrados();

            var listaFinal = usuariosDB.Select(u => new ClUsuarioM
            {
                Nombre = u.Nombre,
                Email = u.Email,
                Rol = u.Rol,
                EstadoCuenta = u.EstadoCuenta
            }).ToList();

            return listaFinal;
        }
    }
}