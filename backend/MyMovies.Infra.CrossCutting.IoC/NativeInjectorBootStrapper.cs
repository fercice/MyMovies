using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Interfaces;
using MyMovies.Infra.Data.Context;
using MyMovies.Infra.Data.Repository;
using MyMovies.Infra.Data.UoW;
using MyMovies.Service.Interfaces;
using MyMovies.Service.Services;

namespace MyMovies.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // AppService
            services.AddScoped<IDiretorAppService, DiretorAppService>();
            services.AddScoped<IFilmeAppService, FilmeAppService>();            
            services.AddScoped<IGeneroAppService, GeneroAppService>();

            // Service            
            services.AddScoped<IService<Diretor>, BaseService<Diretor>>();
            services.AddScoped<IService<Filme>, BaseService<Filme>>();            
            services.AddScoped<IService<Genero>, BaseService<Genero>>();

            // Infra - Data  
            services.AddScoped<MyMoviesContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data - Repository
            services.AddScoped<IRepository<Diretor>, Repository<Diretor>>();
            services.AddScoped<IRepository<Filme>, Repository<Filme>>();            
            services.AddScoped<IRepository<Genero>, Repository<Genero>>();
        }
    }
}