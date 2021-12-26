using FluentValidation;

namespace Application.Features.Personas.Commands.EliminarPersonasCommand
{
    public class EliminarPersonaValidator : AbstractValidator<EliminarPersonaCommand>
    {
        public EliminarPersonaValidator()
        {
            RuleFor(c => c.IdPersona)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
