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
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Must(MayorACero).WithMessage("'{PropertyName}' : el Id debe ser Mayor a Cero");

            RuleFor(c => c.IdTipoDocumento)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Must(MayorACero).WithMessage("'{PropertyName}' : el Id debe ser Mayor a Cero");

            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^([A-Za-z0-9])$").WithMessage("'{PropertyName}' : Solo acepta numero y letras (Mayusculas / Minusculas)");

            RuleFor(x => x.CodigoUnico)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,\s]*$|^[\W]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,espacios Y /)");

            RuleFor(x => x.Imagen)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 250).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z:\s\\/]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,/,\\, :)");
        }

        protected static bool MayorACero(int id)
        {
            return id > 0;
        }
    }

    
}
