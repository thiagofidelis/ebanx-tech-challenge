
using EbanxChallenge.Domain.Repositories;
using EbanxChallenge.Infra.Repositories;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class APIServiceCollectionExtensions
    {
        public static IServiceCollection AddAPIServices(
             this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IAccountRepository, AccountInMemoryRepository>();

            return services;
        }
    }
}