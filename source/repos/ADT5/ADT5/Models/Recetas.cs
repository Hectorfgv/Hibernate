using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADT5.Models
{
    public class Recetas
    {
        public Recetas(int recetaId, string titulo, string comentarios, int dificultad)
        {
            Id = recetaId;
            Titulo = titulo;
            Comentarios = comentarios;
            Dificultad = dificultad;
        }

        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Comentarios { get; set; }
        public int Dificultad { get; set; }
    }
}