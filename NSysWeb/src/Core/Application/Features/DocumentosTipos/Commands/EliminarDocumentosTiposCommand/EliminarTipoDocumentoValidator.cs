using FluentValidation;

namespace Application.Features.DocumentosTipos.Commands.EliminarDocumentosTiposCommand
{
    public class EliminarDocumentoTipoValidator : AbstractValidator<EliminarDocumentoTipoCommand>
    {
        public EliminarDocumentoTipoValidator()
        {
            RuleFor(i => i.IdDocumentoTipo)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
