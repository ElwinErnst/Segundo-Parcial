using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MenuPrincipal;
using AdmProyectos.Entidades;
using AdmProyectos.Controladores;
using System.IO;

namespace AdmProyectos.Controladores
{
    class nProyecto
    {
        public static void ListarProyectosXHoras()
        {
            foreach(Proyecto w in pProyecto.GetAll())
            {
                int count = 0;
                int i = 0;
                int[] b = new int[pProyecto.GetAll().Count];
                Proyecto p = pProyecto.GetAll().ElementAt(Seleccionar());
                foreach (Tarea r in p.Tareas)
                {
                    b[i] = r.Horasejecutadas + count;
                }
                i = i + 1;

            }
        }
        
        public static void AgregarTarea()
        {
            Proyecto p = pProyecto.GetAll().ElementAt(Seleccionar());

            Tarea t = new Tarea();

            Console.WriteLine("Ingrese ID");
            t.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Descripcion");
            t.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese ID de encargado");
            int a = int.Parse(Console.ReadLine());
            t.Encargado = pPersona.GetById(a);
            t.Estado = pEstado.GetById(1);
            Console.WriteLine("Ingrese horas del plan");
            t.Horasplan = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese horas ejecutadas");
            t.Horasejecutadas = int.Parse(Console.ReadLine());
            p.Tareas.Add(t);
            pTarea.Save(t);
        }

        public static void Reporte()
        {
            Proyecto p = pProyecto.GetAll().ElementAt(Seleccionar());
            Console.WriteLine("Titulo: " + p.Titulo + ", Lider: "+ p.Lider.Nombre);
            Console.WriteLine("");

            foreach(Persona pers in p.Integrantes)
            {
                Console.WriteLine("id: {0}, Nombre: {1}", pers.Id, pers.Nombre);
            }
            Console.ReadKey();
        }

        public static int Seleccionar()
        {
            int s;
            Listar();
            Console.WriteLine("Seleccione un Proyecto: ");
            s = int.Parse(Console.ReadLine());

            return s - 1;
        }

        public static void Listar()
        {
            //string[] lista = new string[pProyecto.GetAll().Count];

            foreach(Proyecto r in pProyecto.GetAll())
            {
                //lista[pProyecto.GetAll().IndexOf(r)] = r.Id + " " + r.Titulo;
                Console.WriteLine("ID: {0},  Titulo: {1}", r.Id, r.Titulo);
            }
            //Herramientas.DibujoMenu("Registros", lista);
        }

        public static void RegistrosTxt()
        {

            Console.Clear();
            StreamWriter sw = new StreamWriter("C:\\Users\\MI\\Desktop\\AdmProyectos\\AdmProyectos\\bin\\Debug\\hola.txt", false);

            Proyecto p = pProyecto.GetAll().ElementAt(Seleccionar());

            Console.WriteLine("Titulo: " + p.Titulo + ", Lider: " + p.Lider.Nombre);
            Console.WriteLine("");

            List<Persona> aux = new List<Persona>();
                foreach (Persona pers in p.Integrantes)
                {
                    sw.WriteLine("id: {0}, Nombre: {1}", pers.Id, pers.Nombre);
                }
            sw.Close();
            Console.Clear();
            Console.WriteLine(".");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Thread.Sleep(150);
            Console.WriteLine("Su archivo de Registro fue creado exitosamente!");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Thread.Sleep(150);
            Console.WriteLine(".");
            Thread.Sleep(50);
        }

        public static void ReporteDeProyecto()
        {
            int counta = 0;
            int countb = 0;
            int countc = 0;
            foreach (Proyecto p in pProyecto.GetAll())
            {
                Console.WriteLine("titulo: " + p.Titulo + ", Lider: " + p.Lider.Nombre);
                Console.WriteLine("cant. Integrantes: " + p.Integrantes.Count());

                
                foreach (Tarea t in p.Tareas)
                {
                    if(t.Estado.Id == 1)
                    {
                        counta = counta + 1;
                    }
                    if (t.Estado.Id == 2)
                    {
                        countb = countb + 1;
                    }
                    if (t.Estado.Id == 3)
                    {
                        countc = countc + 1;
                    }
                }
                Console.WriteLine("Tareas asignadas: " + counta);
                Console.WriteLine("Tareas proceso: " + countb);
                Console.WriteLine("Tareas proceso: " + countc);
                Console.ReadKey();
            }
        }
    }
}
