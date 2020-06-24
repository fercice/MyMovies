using System;
using System.Collections.Generic;

namespace MyMovies.Domain.Entities
{
    public class Genero : Entity
    {
        // Empty constructor for EF
        protected Genero() { }

        public string Nome { get; set; }

        public IList<Filme> Filmes { get; set; }
    }
}

