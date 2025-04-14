using Microsoft.Extensions.DependencyInjection;
using Services.Profiles.Interfaces;
using Services.Profiles;
using Services.States.Interfaces;
using Services.States;

namespace Services
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationDIRespositories(
            this IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IStatesServices, StatesService>();

            return services;
        }
    }
}
