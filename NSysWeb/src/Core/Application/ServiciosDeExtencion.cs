using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using System;
using System.Reflection;

namespace Application
{
    public static class ServiciosDeExtencion
    {
        // Agrupar las matriculas de los servicios

        public static void AgregaCoreDeAplicacion(this IServiceCollection serviciosColeccion, IWebHostEnvironment webHostEnvironment)
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

            // Agregamos para la instancia de GeometryServices
            //serviciosColeccion.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

            //serviciosColeccion.AddSingleton(provider =>
            //    new MapperConfiguration(config =>
            //    {
            //        var geometryFactory = provider.GetRequiredService<GeometryFactory>();
            //        config.AddProfile(new Auto)
            //    }).CreateMapper()
            //);

            // Fluent Validation la validacion va en application
            serviciosColeccion.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly() );

            // matriulamos el servicio MediaTr implementa el patron mediador
            serviciosColeccion.AddMediatR(Assembly.GetExecutingAssembly());

            // No funcionaba el validator por que faltaba agregarlo a la tuberia 
            // Registrar el behaivor la parte donde valida y controla los datos de los campos
            // ahora si me debe tomar en cuenta las reglas de validacion
            serviciosColeccion.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Registramos Serilog 
            var fechaString = DateTime.Now.ToShortDateString().Replace("/", "-");
            serviciosColeccion.AddLogging(ConstructorDeLoggin =>
            {
                // 1 - Crear la Configuracion
                var ConfiguracionLogger = new LoggerConfiguration()
                    .MinimumLevel.Information() // Reeplazamos la primer linea del AppsettingJson para el log
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // AppSettingJson.Microsoft = Warning
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                    .WriteTo.Console(  // este es para el sink de console ,con el sink de console y se puede configurar cada sink
                      outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] -> {Message} - {Properties} - {NewLine}"
                     // horas:min:seg   3 carac mayusculas
                     )
                    .WriteTo.File($".\\Logs\\{fechaString}_Logs.txt",
                       outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] -> {Message} - {Properties} - {NewLine}"
                    )
                    .Enrich.WithProperty("Ambiente_Ejecucion",webHostEnvironment.EnvironmentName)
                    .Enrich.WithProperty("NombreApp", webHostEnvironment.ApplicationName)
                    .Enrich.WithMachineName()
                    .Enrich.WithEnvironmentUserName()
                    .Enrich.WithAssemblyName()
                    .Enrich.WithAssemblyVersion();

                // 2 - Creal el Logger
                var logger = ConfiguracionLogger.CreateLogger();

                // 3 - Inyectar el Servicios como singleton
                ConstructorDeLoggin.Services.AddSingleton<ILoggerFactory>(
                                // le decimos que use el serilog logger factory viene de serilog extensions
                                // de parametros le decimos que logger tiene que usar (arriba) y no haga el dispose
                    provider => new SerilogLoggerFactory(logger, dispose: false));
            });
            
            // Para poder registrarlos en startup.cs se hace una referencia de WebAPI --> Application
        }
    }
}
 