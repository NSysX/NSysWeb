using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiciosDeExtension
    {
        public static void AgregaInfraestructuraDePersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            // se configura la migracion
            services.AddDbContext<NSysWebDbContexto>(options => 
            options.UseSqlServer(configuration.GetConnectionString("NSysWeb"), r => { 
                    r.MigrationsAssembly(typeof(NSysWebDbContexto).Assembly.FullName);
                    r.UseNetTopologySuite();
                  }));

            // matriculamos 
            #region Repositories
            services.AddTransient(typeof(IRepositorioAsync<>), typeof(MiRepositorioAsync<>));
            #endregion

            // configuracion de REDIS
            #region Caching
            services.AddStackExchangeRedisCache(opt =>
            {
                // en que puerto esta corriendo redis
                opt.Configuration = configuration.GetValue<string>("Caching:RedisConnection");
            });
            #endregion
        }
    }
}