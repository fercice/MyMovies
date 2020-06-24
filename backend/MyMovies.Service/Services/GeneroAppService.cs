using AutoMapper;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Exceptions;
using MyMovies.Domain.Interfaces;
using MyMovies.Domain.Validators;
using MyMovies.Service.Interfaces;
using MyMovies.Service.ViewModels;
using System;
using System.Linq;

namespace MyMovies.Service.Services
{
    public class GeneroAppService : BaseAppService<Genero, GeneroViewModel, GeneroValidator>, IGeneroAppService
    {
        private readonly IMapper mapper;
        private readonly IService<Genero> service;

        public GeneroAppService(IMapper mapper, IService<Genero> service)
            : base(mapper, service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public GeneroViewModel InsertOrUpdateWithVerification(GeneroViewModel viewModel)
        {
            GeneroViewModel GeneroViewModel = ObterPorNome(viewModel.Nome);

            if (GeneroViewModel == null)
            {
                return InsertOrUpdate(viewModel);
            }
            else
            {
                if (GeneroViewModel.Id == viewModel.Id)
                {
                    return InsertOrUpdate(viewModel);
                }
                else
                {
                    throw new ServiceException("Genero já existe");
                }
            }
        }

        private GeneroViewModel ObterPorNome(string nome)
        {
            return mapper.Map<GeneroViewModel>(service.Select().Where(e => e.Nome.Equals(nome)).FirstOrDefault());
        }
    }
}
