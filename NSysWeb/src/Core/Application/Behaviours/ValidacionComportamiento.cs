using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    /*
     * esta clase recibe 2 tipos unos de peticion y otro de respuesta
     * y se le implementa un interfaz de mediatr donde Tpeticion es una implementacion de IRequest 
     */
    public class ValidacionComportamiento<TPeticion, TRespuesta> : IPipelineBehavior<TPeticion, TRespuesta> where TPeticion : IRequest<TPeticion> /* alomejor debe ser TResponse */
    {
        // validamos antes de que llegue al manejador principal
        private readonly IEnumerable<IValidator<TPeticion>> _validador;

        public ValidacionComportamiento(IEnumerable<IValidator<TPeticion>> validador)
        {
            _validador = validador;
        }

        //es propia del system threading
        // la implementaciond e la interfaz de IPipelinebehaviour
        public async Task<TRespuesta> Handle(TPeticion peticion, CancellationToken cancellationToken, RequestHandlerDelegate<TRespuesta> next)
        {
            // si hay un validador implementado a traves del la tuberia, algun comando que son los que tienen reglas de  negocio
            if(_validador.Any())
            {
                // se crea un objeto para que agarre el TPeticion o la peticion , que esta entrando
                var contexto = new FluentValidation.ValidationContext<TPeticion>(peticion);
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

            // sigua la peticion
            return await next();
        }
    }
}
