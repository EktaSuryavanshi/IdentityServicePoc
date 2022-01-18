using Microsoft.Extensions.DependencyInjection;
using Poc.Infrastructure.Repositories;

namespace Poc.Infrastructure;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IIdentityRepository, IdentityRepository>();

        return services;
    }
}