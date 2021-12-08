using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TiposDocumentos.Commands.ActualizarTiposDocumentosCommand
{
    public class ActualizarTipoDocumentoValidator : AbstractValidator<ActualizarTipoDocumentoCommand>
    {
        public ActualizarTipoDocumentoValidator()
        {
           RuleFor(i => i.IdTipoDocumento)
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
                .Length(3, 35).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres");

            RuleFor(a => a.Abreviacion)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(l => l.Longitud)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .Must(longitudValida).WithMessage("'{PropertyName}' : Longitud debe ser mayor a 0 y menor a 30");
        }

        protected static bool longitudValida(int longitud)
        {
            if (longitud <= 0 || longitud > 30)
                return false;

            return true;
        }

        protected static bool EsPositivo(int id)
        {
            return id > 0;
        }
    }
}
