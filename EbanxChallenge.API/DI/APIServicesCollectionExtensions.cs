
using EbanxChallenge.Domain.Repositories;
using EbanxChallenge.Domain.Services;
using EbanxChallenge.Infra.Repositories;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class APIServiceCollectionExtensions
    {
        public static IServiceCollection AddAPIServices(
             this IServiceCollection services, IConfiguration config)
        {
            // Repos
            services.AddSingleton<IAccountRepository, AccountInMemoryRepository>();

            // Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEventService, EventService>();

            return services;
        }
    }
}