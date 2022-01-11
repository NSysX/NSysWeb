using FluentValidation;

namespace Application.Features.Direcciones.Commands.EliminarDireccionesCommand
{
    public class EliminarDireccionValidator : AbstractValidator<EliminarDireccionCommand>
    {
        public EliminarDireccionValidator()
        {
             RuleFor(i => i.IdDireccion)
               .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
               .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
