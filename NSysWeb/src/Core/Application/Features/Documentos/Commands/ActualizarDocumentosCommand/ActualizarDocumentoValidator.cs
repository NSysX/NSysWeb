using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Documentos.Commands.ActualizarDocumentosCommand
{
    public class ActualizarDocumentoValidator : AbstractValidator<ActualizarDocumentoCommand>
    {
        public ActualizarDocumentoValidator()
        {
            RuleFor(c => c.IdDocumento)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .GreaterThan(0).WithMessage("'{PropertyName}' : el Id debe ser Mayor a Cero");

            RuleFor(c => c.IdDocumentoTipo)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .GreaterThan(0).WithMessage("'{PropertyName}' : el Id debe ser Mayor a Cero");

            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^([A-Za-z0-9])$").WithMessage("'{PropertyName}' : Solo acepta numero y letras (Mayusculas / Minusculas)");

            RuleFor(x => x.CodigoUnico)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[A-Z0-9áéíóúñÑ.,\s]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,espacios Y Numeros)");

            RuleFor(x => x.Foto)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 250).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z:.\s\\/]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas, Minusculas,/,\\, :)");
        }
    } 
}
