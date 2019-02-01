using ADT5.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADT5.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadoRepository();
            List<Mercado> mercados = repo.Retrieve();
            return mercados;
        }

        //Get api/mercados?id_evento=id
        
        public IEnumerable<Mercado> GetIdEvento(int id_evento)
        {
            var repo = new MercadoRepository();
            List<Mercado> mercados = repo.RetrieveIdEvento(id_evento);
            return mercados;
        }
        
        public Mercado GetDatos(int id_evento, double over_under)
        {
            var repo = new MercadoRepository();
            Mercado mercados = repo.RetrieveDatos(id_evento, over_under);
            return mercados;
        }

        // POST: api/Mercado
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadoRepository();
            repo.Save(mercado);
        }

        

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        public void Put([FromBody]Mercado mercado)
        {
            var repo = new MercadoRepository();
            repo.Save(mercado);
        }
        public void PutDinero(int id_evento, double over_under, double dinero, int apuesta)
        {
            var repo = new MercadoRepository();
            repo.insertarDinero(dinero, apuesta, id_evento, over_under);
        }


        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
