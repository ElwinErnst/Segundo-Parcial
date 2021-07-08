using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AdmProyectos.Entidades;

namespace AdmProyectos.Controladores
{
    class pTarea
    {
        public static void Save(Tarea t)
        {

            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Tareas (id, descripcion, estado_id, horas_plan, horas_ejecutadas, Persona_id) VALUES (@id, @descripcion, @estado_id, @horas_plan, @horas_ejecutadas, @Persona_id)");
            cmd.Parameters.Add(new SQLiteParameter("@id", t.Id));
            cmd.Parameters.Add(new SQLiteParameter("@descripcion", t.Descripcion));
            cmd.Parameters.Add(new SQLiteParameter("@estado_id", t.Estado.Id));
            cmd.Parameters.Add(new SQLiteParameter("@horas_plan", t.Horasplan));
            cmd.Parameters.Add(new SQLiteParameter("@horas_ejecutadas", t.Horasejecutadas));
            cmd.Parameters.Add(new SQLiteParameter("@Persona_id", t.Encargado.Id));

            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static List<Tarea> GetAllbyProyecto(int proyecto_id)
        {

            List<Tarea> tareas = new List<Tarea>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT id, descripcion, horas_plan, horas_ejecutadas, persona_id, estado_id FROM Tareas where proyecto_id = @proyecto_id");
            cmd.Parameters.Add(new SQLiteParameter("@proyecto_id", proyecto_id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            while (obdr.Read())
            {
                Tarea t = new Tarea();
                t.Id = obdr.GetInt32(0);
                t.Descripcion = obdr.GetString(1);
                t.Horasplan = obdr.GetInt32(2);
                t.Horasejecutadas = obdr.GetInt32(3);
                t.Encargado = pPersona.GetById(obdr.GetInt32(4));
                t.Estado = pEstado.GetById(obdr.GetInt32(5));


                tareas.Add(t);
            }
            return tareas;
        }
    }
}
