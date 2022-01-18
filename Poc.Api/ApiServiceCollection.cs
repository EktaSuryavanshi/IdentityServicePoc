using Poc.Core;

namespace Poc.Api
{
    public static class ApiServiceCollection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddCoreServices();
            return services;
        }
    }
}
