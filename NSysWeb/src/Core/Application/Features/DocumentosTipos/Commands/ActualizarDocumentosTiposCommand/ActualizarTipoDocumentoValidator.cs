using Application.Features.DocumentosTipos.Commands.ActualizarDocumentosTiposCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DocumentosTipos.Commands.ActualizarDocumentosTiposCommand
{
    public class ActualizarDocumentoTipoValidator : AbstractValidator<ActualizarDocumentoTipoCommand>
    {
        public ActualizarDocumentoTipoValidator()
        {
           RuleFor(i => i.IdDocumentoTipo)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
            
            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(1, 1).WithMessage("'{PropertyName}' : Longitud de 1 caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]{1}$").WithMessage("'{PropertyName}' : Solo Acepta un caracter Alfanumerico");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(3, 35).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres");

            RuleFor(a => a.Abreviatura)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(l => l.Longitud)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .Must(longitudValida).WithMessage("'{PropertyName}' : Longitud debe ser mayor a 0 y menor a 30");
        }

        protected static bool longitudValida(int longitud) => (longitud <= 0 || longitud > 30) ? false : true;
    }
}
