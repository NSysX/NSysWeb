using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Estados.Commands.ActualizarEstadosCommand
{
    public class ActualizarEstadoValidator : AbstractValidator<ActualizarEstadoCommand>
    {
        public ActualizarEstadoValidator()
        {
            RuleFor(i => i.IdEstado)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede Estar Vacio")
                .Must(EsPositivo).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(1, 1).WithMessage("'{PropertyName}' : Longitud de 1 caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]{1}$").WithMessage("'{PropertyName}' : Solo Acepta un caracter Alfanumerico");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(3, 20).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres");

            RuleFor(a => a.Abreviatura)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(2, 3).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");
        }

        protected static bool EsPositivo(int id)
        {
            return id > 0;
        }
    }
}
