using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiciosDeExtencion
    {
        // Agrupar las matriculas de los servicios

        public static void AgregaCoreDeAplicacion(this IServiceCollection serviciosColeccion)
        {
           // voy a matricular 3 servicios
           /* esto es lo que se hace en el startup.cs de la aplicacion 
               como tenemos un desacoplo total de la aplicacion no dependemos t
               total de ese archivo

            lo que nos permite poder utilizarlos fuera del startup es el paquete 
            de los nugets que dice dependencyInjection
           */
            
            // Revise automaticamente los mapeos que haga en esta biblioteca de clases
            serviciosColeccion.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Fluent Validation la validacion va en application
            serviciosColeccion.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // matriulamos el servicio MediaTr implementa el patron mediador
            serviciosColeccion.AddMediatR(Assembly.GetExecutingAssembly());

            // No funcionaba el validator por que faltaba agregarlo a la tuberia 
            // Registrar el behaivor la parte donde valida y controla los datos de los campos
            // ahora si me debe tomar en cuenta las reglas de validacion
            serviciosColeccion.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Para poder registrarlos en startup.cs se hace una referencia de WebAPI --> Application

        }
    }
}
 