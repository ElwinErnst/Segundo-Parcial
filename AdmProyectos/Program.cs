using AdmProyectos.Controladores;
using AdmProyectos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmProyectos;
namespace AdmProyectos
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexion.OpenConnection();
            Menu();
            Conexion.CloseConnection();
        }
        public static void Menu()
        {
            Console.Clear();
            string[] opciones = new string[6] { "Punto 1", "Punto 2", "Punto 2.b (opcion txt)", "Punto 3", "PUNTO 4", "Salir"};
            int l = opciones.Length;
            string titulo = "Parcial";
            MenuPrincipal.Herramientas.DibujoMenu(titulo, opciones);
            Console.WriteLine("Ingrese una opción: ");
            int op = MenuPrincipal.Herramientas.LeerEntero(1, l);

            switch (op)
            {
                case 1: nProyecto.AgregarTarea(); Menu(); break;
                case 2: nProyecto.Reporte(); Menu(); break;
                case 3: nProyecto.RegistrosTxt(); Menu(); break;
                case 4: nProyecto.ListarProyectosXHoras(); Menu(); break;
                case 5: nProyecto.ReporteDeProyecto(); break;
                default: Menu(); break;
            }
        }
    }
}
