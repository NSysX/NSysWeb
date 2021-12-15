using FluentValidation;

namespace Application.Features.Estados.Commands.EliminarEstadosCommand
{
    public class EliminarEstadoValidator : AbstractValidator<EliminarEstadoCommand>
    {
        public EliminarEstadoValidator()
        {
            RuleFor(i => i.IdEstado)
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
