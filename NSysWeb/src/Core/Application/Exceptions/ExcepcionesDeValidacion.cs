using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Application.Exceptions
{
    // Clase personalizada de exceciones 
    // validaciones personalizadas todas deben de heredar de la clase exception
    public class ExcepcionDeValidacion : Exception
    {
        public List<string> Errores { get;}

        public ExcepcionDeValidacion() : base("Se ha producido uno o mas errores de validacion")
        {
            Errores = new List<string>();
        }

        // validation Failure son los errores recolectados por el fluent validation
        public ExcepcionDeValidacion(IEnumerable<ValidationFailure> fallos) : this()
        {
            foreach (var fallo in fallos)
            {
                Errores.Add(fallo.ErrorMessage);
            }
        }
    }
}
