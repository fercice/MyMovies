using System;
using System.Collections.Generic;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Validators;
using MyMovies.Service.ViewModels;

namespace MyMovies.Service.Interfaces
{
    public interface IFilmeAppService : IAppService<Filme, FilmeViewModel, FilmeValidator>
    {
        FilmeViewModel ObterFilmesPorId(int id);         

        IEnumerable<FilmeViewModel> ObterFilmesPorDiretor(int id);

        IEnumerable<FilmeViewModel> SelectLazyload();
    }
}

