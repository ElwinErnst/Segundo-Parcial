using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AdmProyectos.Entidades;

namespace AdmProyectos.Controladores
{
    class pPersona
    {
        public static List<Persona> GetAll()
        {

            List<Persona> personas = new List<Persona>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido FROM Personas");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            while (obdr.Read())
            {
                Persona a = new Persona();
                a.Id = obdr.GetInt32(0);
                a.Nombre = obdr.GetString(1);
                a.Apellido = obdr.GetString(2);
              

                personas.Add(a);
            }
            return personas;
        }

        public static Persona GetById(int id)
        {
            Persona a = new Persona();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido FROM Personas WHERE id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            while (obdr.Read())
            {

                a.Id = obdr.GetInt32(0);
                a.Nombre = obdr.GetString(1);
                a.Apellido = obdr.GetString(2);

            }
            return a;

        }

        public static List<Persona> GetAllbyProyecto(int proyecto_id)
        {

            List<Persona> personas = new List<Persona>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT persona_id FROM PersonasProyecto where proyecto_id = @proyecto_id");
            cmd.Parameters.Add(new SQLiteParameter("@proyecto_id", proyecto_id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            while (obdr.Read())
            {
                Persona a = GetById(obdr.GetInt32(0));


                personas.Add(a);
            }
            return personas;
        }
    }
}
