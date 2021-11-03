using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared
{
    // 1- Se Hace estatica
    public static class ServiciosDeExtencion
    {
        // 2- se crea un metodo void 
        // para registrar la inyeccion de dependencias
        public static void AgregaInfraestructuraDeShared(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IFechaHoraServicio, FechaHoraServicio>();
        }
    }
}