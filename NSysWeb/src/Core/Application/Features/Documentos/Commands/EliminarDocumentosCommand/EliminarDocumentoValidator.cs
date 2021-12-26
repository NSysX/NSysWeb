using FluentValidation;

namespace Application.Features.Documentos.Commands.EliminarDocumentosCommand
{
    public class EliminarDocumentoValidator : AbstractValidator<EliminarDocumentoCommand>
    {
        public EliminarDocumentoValidator()
        {
            RuleFor(i => i.IdDocumento)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
