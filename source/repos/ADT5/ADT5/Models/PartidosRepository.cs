using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ADT5.Models
{
    public class PartidosRepository
    {   
        private MySqlConnection Connect()
        {
            String connString = "Server=localhost;Port=3306;Database=apiweb;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);            
            return con;
        }
        internal List<Partido> Retrieve() 
        {
            MySqlConnection con = Connect();            
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Partido p = null;
                List<Partido> partidos = new List<Partido>();

                while (res.Read())
                {
                    Debug.WriteLine("Datos de partido: " + res.GetInt32(0) + " Equipo Local: " + res.GetString(1) +
                        " Equipo Visitante: " + res.GetString(2) + " Goles: " + res.GetInt32(3));
                    p = new Partido(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    partidos.Add(p);
                }
                con.Close();
                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }
            
           

        }

        internal List<Partido> RetrieveGoles(int goles)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos where goles = "+goles;


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Partido p = null;
                List<Partido> partidos = new List<Partido>();

                while (res.Read())
                {
                    Debug.WriteLine("Datos de partido: " + res.GetInt32(0) + " Equipo Local: " + res.GetString(1) +
                        " Equipo Visitante: " + res.GetString(2) + " Goles: " + res.GetInt32(3));
                    p = new Partido(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    partidos.Add(p);
                }
                con.Close();
                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }



        }

        internal void Save(Partido p)
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into eventos(local,visitante,goles) values ('"+p.Local+"','"+p.Visitante+"','"+p.Goles+"')";
            Debug.WriteLine("comando " + command.CommandText);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");

            }
        }

        internal Partido Objeto()
        {
            Partido e = new Partido(5, "Betis", "Espanyol", 4);
            return e;
        }
    }

}