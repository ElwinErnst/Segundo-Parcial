using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmProyectos.Entidades
{
    class Proyecto
    {
        int id;
        string titulo;
        Persona lider;
        List<Persona> integrantes;
        List<Tarea> tareas;

        public Proyecto()
        {
            integrantes = new List<Persona>();
            tareas = new List<Tarea>();
        }

        public Proyecto(int id, string titulo, Persona lider, List<Persona> integrantes, List<Tarea> tareas)
        {
            this.id = id;
            this.titulo = titulo;
            this.lider = lider;
            this.integrantes = integrantes;
            this.tareas = tareas;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public Persona Lider { get => lider; set => lider = value; }
        public List<Persona> Integrantes { get => integrantes; set => integrantes = value; }
        public List<Tarea> Tareas { get => tareas; set => tareas = value; }
    }
}
