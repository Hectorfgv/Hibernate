using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADT5.Models
{
    public class Partido
    {
        public Partido(int partidoId, string local, string visitante, int goles)
        {
            PartidoId = partidoId;
            Local = local;
            Visitante = visitante;
            Goles = goles;  
        }

        public int PartidoId { get; set; }
        public String Local { get; set; }
        public String Visitante { get; set; }
        public int Goles { get; set; }
    }
}