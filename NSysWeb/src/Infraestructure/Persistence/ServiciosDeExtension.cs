using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiciosDeExtension
    {
        public static void AgregaInfraestructuraDePersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            // i se configura la migracion
            services.AddDbContext<NSysWebDbContexto>(options => options.UseSqlServer(
                configuration.GetConnectionString("NSysWeb"), b => b.MigrationsAssembly(typeof(NSysWebDbContexto).Assembly.FullName)));

            // matriculamos 
            #region Repositories
            services.AddTransient(typeof(IRepositorioAsync<>), typeof(MiRepositorioAsync<>));
            #endregion
        }
    }
}
