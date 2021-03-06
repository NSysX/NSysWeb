using FluentValidation;

namespace Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand
{
    public class EliminarEstadoCivilValidador : AbstractValidator<EliminarEstadoCivilCommand>
    {
        public EliminarEstadoCivilValidador()
        {
            RuleFor(i => i.IdEstadoCivil)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
