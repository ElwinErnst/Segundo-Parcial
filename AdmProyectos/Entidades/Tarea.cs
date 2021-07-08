using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmProyectos.Entidades
{
    class Tarea
    {
        int id;
        string descripcion;
        Persona encargado;
        Estado estado;
        int horasplan;
        int horasejecutadas;

        public Tarea()
        { 
        }

        public Tarea(int id, string descripcion, Persona encargado, Estado estado, int horasplan, int horasejecutadas)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.encargado = encargado;
            this.estado = estado;
            this.horasplan = horasplan;
            this.horasejecutadas = horasejecutadas;
        }

        public int Id { get => id; set => id = value; }
        public int Horasplan { get => horasplan; set => horasplan = value; }
        public int Horasejecutadas { get => horasejecutadas; set => horasejecutadas = value; }
        
        public string Descripcion { get => descripcion; set => descripcion = value; }
        internal Persona Encargado { get => encargado; set => encargado = value; }
        internal Estado Estado { get => estado; set => estado = value; }
    }
}
 