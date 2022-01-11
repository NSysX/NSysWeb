using FluentValidation;

namespace Application.Features.AsentamientosTipos.Commands.EliminarAsentamientosTipos
{
    public class EliminarAsentamientoTipoValidator : AbstractValidator<EliminarAsentamientoTipoCommand>
    {
        public EliminarAsentamientoTipoValidator()
        {
            RuleFor(i => i.IdAsentamientoTipo)
               .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
               .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
