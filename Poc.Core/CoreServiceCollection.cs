using Microsoft.Extensions.DependencyInjection;
using Poc.Infrastructure;

namespace Poc.Core;
public static class CoreServiceCollection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddInfrastructureServices();
        return services;
    }
}