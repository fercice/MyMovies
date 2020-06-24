using AutoMapper;
using System;
using Microsoft.Extensions.DependencyInjection;
using MyMovies.Service.AutoMapper;
using System.Reflection;

namespace MyMovies.Presentation.Api.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            MyMovies.Service.AutoMapper.AutoMapperConfig.RegisterMappings();
        }
    }
}