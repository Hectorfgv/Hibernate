using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADT5.Models
{
    public class Mercado
    {
        public Mercado(double over_under, double cuota_over, double cuota_under )
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;

        }

        public Mercado(int id,int id_evento, double over_under, double cuota_over, double cuota_under,double dinero_over, double dinero_under)
        {
            Id = id;
            Id_evento = id_evento;
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;

        }

        public int Id { get; set; }
        public int  Id_evento { get; set; }
        public double Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Dinero_over { get; set; }
        public double Dinero_under { get; set; }

    }
}