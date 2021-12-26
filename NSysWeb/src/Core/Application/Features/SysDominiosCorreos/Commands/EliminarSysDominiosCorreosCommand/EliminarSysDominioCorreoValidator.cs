using FluentValidation;

namespace Application.Features.SysDominiosCorreos.Commands.EliminarSysDominiosCorreosCommand
{
    public class EliminarSysDominioCorreoValidator : AbstractValidator<EliminarSysDominioCorreoCommand>
    {
        public EliminarSysDominioCorreoValidator()
        {
            RuleFor(i => i.IdSysDominio)
                    .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                    .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
