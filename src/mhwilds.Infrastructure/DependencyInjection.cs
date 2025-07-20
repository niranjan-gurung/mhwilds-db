using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Infrastructure.Data.Context;
using mhwilds.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mhwilds.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // database setup
            var connectionString = configuration.GetConnectionString("Database")
                ?? throw new InvalidOperationException("Connection string 'Database' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            // repository registrations
            services.AddScoped<IWeaponRepository, WeaponRepository>();
            services.AddScoped<IArmourRepository, ArmourRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ICharmRepository, CharmRepository>();
            services.AddScoped<IDecorationRepository, DecorationRepository>();

            return services;
        }
    }
}
