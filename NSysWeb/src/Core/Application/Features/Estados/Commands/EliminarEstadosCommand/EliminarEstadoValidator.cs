using FluentValidation;

namespace Application.Features.Estados.Commands.EliminarEstadosCommand
{
    public class EliminarEstadoValidator : AbstractValidator<EliminarEstadoCommand>
    {
        public EliminarEstadoValidator()
        {
            RuleFor(i => i.IdEstado)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
