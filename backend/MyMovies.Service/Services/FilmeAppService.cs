using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Interfaces;
using MyMovies.Domain.Validators;
using MyMovies.Service.Interfaces;
using MyMovies.Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MyMovies.Service.Services
{
    public class FilmeAppService : BaseAppService<Filme, FilmeViewModel, FilmeValidator>, IFilmeAppService
    {
        private readonly IMapper mapper;
        private readonly IService<Filme> service;

        public FilmeAppService(IMapper mapper, IService<Filme> service)
            : base(mapper, service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public FilmeViewModel ObterFilmesPorId(int id)
        {
            return SelectLazyload().Where(p => p.Id.Equals(id)).FirstOrDefault();
        }               

        public IEnumerable<FilmeViewModel> ObterFilmesPorDiretor(int id)
        {
            return mapper.Map<IEnumerable<FilmeViewModel>>(service.Select().Where(p => p.DiretorId.Equals(id)).ToList());
        }

        public IEnumerable<FilmeViewModel> SelectLazyload()
        {
            var query = CreateQuery()
                .Include(x => x.Diretor)
                .Include(x => x.Genero)
                .AsNoTracking();

            return mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeViewModel>>(query.ToList());
        }
    }
}
