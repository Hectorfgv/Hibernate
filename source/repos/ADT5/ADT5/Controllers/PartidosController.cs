using ADT5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADT5.Controllers
{
    public class PartidosController : ApiController
    {
        // GET: api/Partidos
        public IEnumerable<Partido> Get()
        {
            var repo = new PartidosRepository();
            List<Partido> partidos =  repo.Retrieve();
            return partidos;
        }
        //Get api/partidos?goles=goles
        public IEnumerable<Partido> GetGoles(int goles)
        {
            var repo = new PartidosRepository();
            List<Partido> partidos = repo.RetrieveGoles(goles);
            return partidos;
        }

        // GET: api/Partidos/5
        public Partido Get(int id)
        {

            /* var repo = new PartidosRepository();
             Partido p = repo.Retrieve();
             return p;*/
            return null;
        }

        // POST: api/Partidos insert
        public void Post([FromBody]Partido partido)
        {
            var repo = new PartidosRepository();
            repo.Save(partido);
        }

        // PUT: api/Partidos/5 update
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Partidos/5
        public void Delete(int id)
        {
        }
    }
}
