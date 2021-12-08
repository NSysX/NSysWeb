﻿using FluentValidation;

namespace Application.Features.Documentos.Commands.EliminarDocumentosCommand
{
    public class EliminarDocumentoValidator : AbstractValidator<EliminarDocumentoCommand>
    {
        public EliminarDocumentoValidator()
        {
            RuleFor(i => i.IdDocumento)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede Estar Vacio")
                .Must(EsPositivo).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }

        protected static bool EsPositivo(int id)
        {
            return id > 0;
        }
    }
}
