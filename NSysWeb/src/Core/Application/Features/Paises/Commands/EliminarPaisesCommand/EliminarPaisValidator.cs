using FluentValidation;

namespace Application.Features.Paises.Commands.EliminarPaisesCommand
{
    public class EliminarPaisValidator : AbstractValidator<EliminaPaisCommand>
    {
        public EliminarPaisValidator()
        {
            RuleFor(i => i.IdPais)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
