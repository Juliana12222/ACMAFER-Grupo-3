using AppAcmafer.Datos;
using AppAcmafer.Logica;
using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AppAcmafer.Vista
{
    public class ClUsuarioL
    {
        private ClUsuarioD oUsuarioD = new ClUsuarioD();

        // 📌 CORRECCIÓN: El método debe devolver una LISTA 📌
        public List<ClUsuarioM> ListarUsuarios()
        {
            // Lógica de Negocio: Puedes poner validaciones aquí si las necesitas

            // Llama a la Capa de Datos y devuelve la lista completa
            List<ClUsuarioM> usuarios = oUsuarioD.ListarUsuariosDB();

            return usuarios ?? new List<ClUsuarioM>(); // Aseguramos que nunca sea null
        }
    }
}