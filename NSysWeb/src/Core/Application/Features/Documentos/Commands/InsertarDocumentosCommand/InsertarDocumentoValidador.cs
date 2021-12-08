﻿using FluentValidation;

namespace Application.Features.Documentos.Commands.InsertarDocumentosCommand
{
    public class InsertarDocumentoValidador : AbstractValidator<InsertarDocumentoCommand>
    {
        public InsertarDocumentoValidador()
        {
            RuleFor(t => t.IdTipoDocumento)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO");

            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO")
                .Length(1).WithMessage("'{PropertyName}' : Solo debe tener una Letra")
                .Matches(@"[A-Za-z0-9]").WithMessage("'{PropertyName}' : Solo acepta Caracteres Alfanumericos");

            RuleFor(c => c.CodigoUnico)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO");

            RuleFor(i => i.Imagen)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(1,250).WithMessage("'{PropertyName}' : No debe tener mas de 250 caracteres")
                .Matches(@"^[A-Za-z0-9:\\.]*$");
        }
    }
}
