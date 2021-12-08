using FluentValidation;

namespace Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand
{
    public class EliminarEstadoCivilValidador : AbstractValidator<EliminarEstadoCivilCommand>
    {
        public EliminarEstadoCivilValidador()
        {
            RuleFor(i => i.IdEstadoCivil)
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
