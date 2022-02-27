using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class EjemploDeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        // el constructor que basicamente va a tener el pipeline
        public EjemploDeMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._logger = loggerFactory.CreateLogger(typeof(EjemploDeMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            // Podemos acceder al contenedor de dependencias
            // basicamente el controlador de dependencias
            // context.RequestServices.GetService<T>

            // para el ejemplo del tiempo de la peticion
            Guid traceId = Guid.NewGuid();
            this._logger.LogTrace($"Request(peticion): {traceId} iniciada");
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Ejecutamos el middleware
            await this._next(context);
            
            // despues de que la request ha terminado
            // queremos registrar el tiempo que tarda en ejecutarse cierta peticion respuesta en un logger
            stopwatch.Stop();
            // mostramos el tiempo en el logger
            TimeSpan timeSpan = stopwatch.Elapsed;

            string tiempoConsumido = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            this._logger.LogInformation($"La Peticion con el Guid = {traceId} ha tardado {tiempoConsumido}");
        }
    }
}
