using AutoMapper;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Exceptions;
using MyMovies.Domain.Interfaces;
using MyMovies.Domain.Validators;
using MyMovies.Service.Interfaces;
using MyMovies.Service.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Service.Services
{
    public class DiretorAppService : BaseAppService<Diretor, DiretorViewModel, DiretorValidator>, IDiretorAppService
    {
        private readonly IMapper mapper;
        private readonly IService<Diretor> service;

        public DiretorAppService(IMapper mapper, IService<Diretor> service)
            : base(mapper, service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public DiretorViewModel InsertOrUpdateWithVerification(DiretorViewModel viewModel)
        {
            DiretorViewModel DiretorViewModel = ObterPorNome(viewModel.Nome);

            if (DiretorViewModel == null)
            {
                return InsertOrUpdate(viewModel);
            }
            else
            {
                if (DiretorViewModel.Id == viewModel.Id)
                {
                    return InsertOrUpdate(viewModel);
                }
                else
                {
                    throw new ServiceException("Genero já existe");
                }
            }
        }

        private DiretorViewModel ObterPorNome(string nome)
        {
            return mapper.Map<DiretorViewModel>(service.Select().Where(e => e.Nome.Equals(nome)).FirstOrDefault());
        }
    }
}
