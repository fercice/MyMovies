using AutoMapper;

namespace MyMovies.Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());                
            });
        }
    }
}
