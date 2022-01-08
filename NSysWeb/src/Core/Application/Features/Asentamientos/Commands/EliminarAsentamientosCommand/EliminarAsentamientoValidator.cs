using FluentValidation;

namespace Application.Features.Asentamientos.Commands.EliminarAsentamientosCommand
{
    public class EliminarAsentamientoValidator : AbstractValidator<EliminarAsentamientoCommand>
    {
        public EliminarAsentamientoValidator()
        {
            RuleFor(t => t.IdAsentamiento)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
