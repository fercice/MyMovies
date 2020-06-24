using System;
using System.Collections.Generic;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Validators;
using MyMovies.Service.ViewModels;

namespace MyMovies.Service.Interfaces
{
    public interface IDiretorAppService : IAppService<Diretor, DiretorViewModel, DiretorValidator>
    {
        DiretorViewModel InsertOrUpdateWithVerification(DiretorViewModel viewModel);        
    }
}

