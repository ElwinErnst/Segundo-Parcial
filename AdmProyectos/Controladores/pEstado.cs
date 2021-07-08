using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AdmProyectos.Entidades;
namespace AdmProyectos.Controladores
{
    class pEstado
    {
        public static List<Estado> GetAll()
        {
            List<Estado> estados = new List<Estado>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre FROM Estados");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                Estado a = new Estado();
                a.Id = obdr.GetInt32(0);
                a.Nombre = obdr.GetString(1);
                estados.Add(a);
            }
            return estados;
        }

        public static Estado GetById(int id)
        {
            Estado a = new Estado();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre FROM estados WHERE id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            while (obdr.Read())
            {

                a.Id = obdr.GetInt32(0);
                a.Nombre = obdr.GetString(1);
            }
            return a;
        }
    }
}