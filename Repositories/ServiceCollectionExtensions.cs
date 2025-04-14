using Microsoft.Extensions.DependencyInjection;
using Repositories.Profiles.Interfaces;
using Repositories.Profiles;
using Repositories.States.Interfaces;
using Repositories.States;

namespace Repositories
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IStatesRepository, StatesRepository>();
            services.AddScoped<IStatesDataSource, StatesJsonDataSource>();
            services.AddScoped<IProfileDataSource, ProfileDataJsonSource>();

            return services;
        }
    }
}
