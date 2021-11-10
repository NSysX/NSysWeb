using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    /*
     * esta clase recibe 2 tipos unos de request y otro de respuesta
     * y se le implementa un interfaz de mediatr donde TRequest es una implementacion de IRequest 
     */
    // PIPELINE
    public class ValidacionComportamiento<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TRequest> /* alomejor debe ser TResponse */
    {
        // validamos antes de que llegue al manejador principal
        private readonly IEnumerable<IValidator<TRequest>> _validador;

        public ValidacionComportamiento(IEnumerable<IValidator<TRequest>> validador)
        {
            _validador = validador;
        }

        //es propia del system threading
        // la implementaciond e la interfaz de IPipelinebehaviour
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // si hay un validador implementado a traves del la tuberia, algun comando que son los que tienen reglas de  negocio
            if(_validador.Any())
            {
                // se crea un objeto para que agarre el TRequest o la request , que esta entrando
                var contexto = new ValidationContext<TRequest>(request);
                var validacionResultado = await Task.WhenAll(_validador.Select(v => v.ValidateAsync(contexto, cancellationToken)));
                // recolectar los errores puede que no cumpla con las reglas de negocio
                var fallos = validacionResultado.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // si un campo es numerico y tiene caracters lo recolectamos aqui
                // para lanzar una exception generica
                if (fallos.Count != 0)
                {
                    throw new Exceptions.ExcepcionDeValidacion(fallos);
                }
            }

            // sigua la request
            return await next();
        }
    }
}
