using System;
using System.Collections.Generic;

namespace MyMovies.Domain.Entities
{
    public class Filme : Entity
    {
        // Empty constructor for EF
        protected Filme() { }

        public string Titulo { get; set; }

        public string Elenco { get; set; }

        public string Sinopse { get; set; }

        public Diretor Diretor { get; set; }

        public Genero Genero { get; set; }

        public int DiretorId { get; set; }

        public int GeneroId { get; set; }
    }
}

