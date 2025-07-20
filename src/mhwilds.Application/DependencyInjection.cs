using mhwilds.Application.Interfaces.Services;
using mhwilds.Application.Mapping;
using mhwilds.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace mhwilds.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // configure Mapster
            MapsterConfig.Configure();

            // register application services
            services.AddScoped<IWeaponService, WeaponService>();
            services.AddScoped<IArmourService, ArmourService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICharmService, CharmService>();
            services.AddScoped<IDecorationService, DecorationService>();

            return services;
        }
    }
}
