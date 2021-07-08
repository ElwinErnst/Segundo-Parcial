using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AdmProyectos.Entidades;
using AdmProyectos.Controladores;

namespace AdmProyectos.Controladores
{
    class pProyecto
    {
        public static List<Proyecto> GetAll()
        {

            List<Proyecto> proyectos = new List<Proyecto>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT id, titulo, lider_id FROM Proyecto");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            while (obdr.Read())
            {
                Proyecto a = new Proyecto();
                a.Id = obdr.GetInt32(0);
                a.Titulo = obdr.GetString(1);
                a.Lider =  pPersona.GetById(obdr.GetInt32(2));
                a.Integrantes = pPersona.GetAllbyProyecto(a.Id);
                a.Tareas = pTarea.GetAllbyProyecto(a.Id);


                proyectos.Add(a);
            }
            return proyectos;
        }
    }
}
