using System;
using System.Collections.Generic;

namespace MyMovies.Domain.Entities
{
    public class Diretor : Entity
    {
        // Empty constructor for EF
        protected Diretor() { }

        public string Nome { get; set; }

        public IList<Filme> Filmes { get; set; }
    }
}

