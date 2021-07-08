using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmProyectos.Entidades
{
    class Estado
    {
        int id;
        string nombre;

        public Estado( )
        {
            
        }

        public Estado(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }


}
