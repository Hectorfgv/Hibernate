using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ADT5.Models
{
    public class MercadoRepository
    {

        private MySqlConnection Connect()
        {
            String connString = "Server=localhost;Port=3306;Database=apiweb;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> partidos = new List<Mercado>();

                while (res.Read())
                {
                    Debug.WriteLine("Datos de mercado: id: " + res.GetInt32(0) + " id_evento: " + res.GetString(1) +
                        " over_under " + res.GetDouble(2) + " cuota_over: " + res.GetDouble(3)+" cuota_under "+res.GetDouble(4)
                        + " dinero_over " + res.GetDouble(5) + " dinero_under " + res.GetDouble(6));
                    m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5)
                        , res.GetDouble(6));
                    partidos.Add(m);
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
        
        internal List<Mercado> RetrieveIdEvento(int id_evento)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select over_under, cuota_over, cuota_under from mercados where id_evento="+id_evento;


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> partidos = new List<Mercado>();

                while (res.Read())
                {
                    Debug.WriteLine("Cuotas de mercado:  id_evento: " + res.GetDouble(0) +
                        " over_under " + res.GetDouble(1) + " cuota_over: " + res.GetDouble(2));
                       
                    m = new Mercado( res.GetDouble(0), res.GetDouble(1), res.GetDouble(2));
                    partidos.Add(m);
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
        
        internal Mercado RetrieveDatos(int id_evento, double over_under)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados where id_evento=" +id_evento+ " and over_under="+over_under;


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
  

                if (res.Read())
                {
                    Debug.WriteLine("Cuotas de mercado:  id: " + res.GetInt32(0) + " id_evento " + res.GetInt32(1) + " over_under " + res.GetDouble(2) +
                        " cuota_over " + res.GetDouble(3) + " cuota_under: " + res.GetDouble(4)+" dinero_over " + res.GetDouble(5) + " dinero_under " + res.GetDouble(6));

                    m = new Mercado(res.GetInt32(0), res.GetInt32(1),res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetDouble(6));
                }
                con.Close();
                return m;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }



        }

        internal void Save(Mercado m)
        {
            
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into mercados(id_evento,over_under,cuota_over,cuota_under,dinero_over,dinero_under) values ('" + m.Id_evento + "','" + m.Over_under +
                "','" + m.Cuota_over + "'" +",'" + m.Cuota_under + "','" + m.Dinero_over + "','" + m.Dinero_under + "')";
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
        internal void insertarDinero(double dinero, int apuesta,int id_evento, double over_under)
        {
            

            Mercado mer = RetrieveDatos(id_evento, over_under);

            /* if(dinover>0)
             {
                 mer.Dinero_over += dinover;
             }
             else
             {
                 mer.Dinero_under += dinunder;
             }*/
             if (apuesta == 1)
            {
                mer.Dinero_over += dinero;
            }
            else if (apuesta ==2)
            {
                mer.Dinero_under += dinero;
            }
            
                

            mer.Cuota_over = ProbOver(mer.Dinero_over, mer.Dinero_under);
            mer.Cuota_under = ProbUnder(mer.Dinero_under, mer.Dinero_over);

            

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update mercados set cuota_over="+mer.Cuota_over+", cuota_under="+mer.Cuota_under+
               ", dinero_over=" + mer.Dinero_over + ", dinero_under=" + mer.Dinero_under + " where over_under=" +over_under+" and id_evento="+id_evento;
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
        internal double ProbOver(double dinover, double dinunder) {
           double prover = dinover / (dinover + dinunder);
            double cuover = (1 / prover) * 0.95;

            return cuover;
        }
        internal double ProbUnder(double dinunder, double dinover)
        {
            double  prunder = dinunder / (dinunder + dinover);
            double cuunder = (1 / prunder) * 0.95;
            return cuunder;
        }
    }
}