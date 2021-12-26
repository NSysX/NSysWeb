using FluentValidation;

namespace Application.Features.Telefonos.Commands.EliminarTelefonosCommand
{
    public class EliminarTelefonoValidator : AbstractValidator<EliminarTelefonoCommand>
    {
        public EliminarTelefonoValidator()
        {
            RuleFor(i => i.IdTelefono)
                    .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                    .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
