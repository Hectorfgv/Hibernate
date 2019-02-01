using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ADT5.Models
{
    public class RecetasRepository
    {
        private MySqlConnection Connect()
        {
            String connString = "Server=34.220.190.143;Port=3306;Database=cocina;Uid=examen;password=examen;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Recetas> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from recetas";


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Recetas m = null;
                List<Recetas> recetas = new List<Recetas>();

                while (res.Read())
                {
                    Debug.WriteLine("Datos de receta: id: " + res.GetInt32(0) + " Titulo: " + res.GetString(1) +
                        " Comentarios: " + res.GetString(2) + " Difucultad: " + res.GetInt32(3));
                    m = new Recetas(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    recetas.Add(m);
                }
                con.Close();
                return recetas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }



        }
    }
}