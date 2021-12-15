using FluentValidation;

namespace Application.Features.DocumentosTipos.Commands.EliminarDocumentosTiposCommand
{
    public class EliminarDocumentoTipoValidator : AbstractValidator<EliminarDocumentoTipoCommand>
    {
        public EliminarDocumentoTipoValidator()
        {
            RuleFor(i => i.IdDocumentoTipo)
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
