using System;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Validators;
using MyMovies.Service.ViewModels;

namespace MyMovies.Service.Interfaces
{
    public interface IGeneroAppService : IAppService<Genero, GeneroViewModel, GeneroValidator>
    {
        GeneroViewModel InsertOrUpdateWithVerification(GeneroViewModel viewModel);
    }
}