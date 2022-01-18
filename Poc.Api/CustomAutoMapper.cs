using AutoMapper;
using Poc.Core.Mapping;

namespace Poc.Api;
public static class CustomAutoMapper
{
    public static void AddCustomConfigurationAutoMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile(new AutomapperMappingProfile());
        });

        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}
