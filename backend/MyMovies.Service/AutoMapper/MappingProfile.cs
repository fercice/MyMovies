using AutoMapper;
using MyMovies.Domain.Entities;
using MyMovies.Service.ViewModels;

namespace MyMovies.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Diretor, DiretorViewModel>().ReverseMap();
            CreateMap<DiretorViewModel, DiretorSaveViewModel>().ReverseMap();

            CreateMap<Filme, FilmeViewModel>().ReverseMap();
            CreateMap<FilmeViewModel, FilmeSaveViewModel>().ReverseMap();

            CreateMap<Genero, GeneroViewModel>().ReverseMap();
            CreateMap<GeneroViewModel, GeneroSaveViewModel>().ReverseMap();
        }
    }
}
