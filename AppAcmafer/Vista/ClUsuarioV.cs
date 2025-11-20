using AppAcmafer.Logica;
using AppAcmafer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAcmafer.Vista
{
    public class ClUsuarioV
    {
        static void Main(string[] args)
        {

            MostrarLista("Administrador");

            MostrarLista("Cliente");

            Console.WriteLine("\nPresiona cualquier tecla para finalizar...");
            Console.ReadKey();
        }

        static void MostrarLista(string rol)
        {
            Console.WriteLine($"\n=======================================================");
            Console.WriteLine($" Solicitud con Rol: {rol} (Probando Autorización)");
            Console.WriteLine("=======================================================");

            var bll = new ClUsuarioL();
            List<ClUsuarioM> usuarios = bll.ListarUsuariosRegistrados(rol);

            if (usuarios == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OPERACIÓN FALLIDA: Acceso no autorizado por la Lógica de Negocio (BLL).");
                Console.ResetColor();
                return;
            }

            // Impresión de la tabla (solo con los campos solicitados por la HU)
            Console.WriteLine($"| {"NOMBRE",-20} | {"CORREO",-30} | {"ROL",-15} | {"ESTADO",-10} |");
            Console.WriteLine(new string('-', 81));

            foreach (var u in usuarios)
            {
                Console.WriteLine($"| {u.Nombre,-20} | {u.Email,-30} | {u.Rol,-15} | {u.EstadoCuenta,-10} |");
            }
            Console.WriteLine(new string('-', 81));
            Console.WriteLine($"Total de usuarios listados: {usuarios.Count}");
        }
    }
}