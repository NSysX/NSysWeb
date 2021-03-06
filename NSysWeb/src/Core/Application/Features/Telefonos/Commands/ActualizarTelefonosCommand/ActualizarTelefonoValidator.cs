using FluentValidation;

namespace Application.Features.Telefonos.Commands.ActualizarTelefonosCommand
{
    public class ActualizarTelefonoValidator : AbstractValidator<ActualizarTelefonoCommand>
    {
        public ActualizarTelefonoValidator()
        {
            RuleFor(i => i.IdTelefono)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo acepta un Caracter");

            RuleFor(d => d.TipoTelefono)
                .NotNull().WithMessage("{PropertyName} : No debe ser NULL")
                .NotEmpty().WithMessage("{PropertyName} : No debe estar Vacia")
                .Length(3, 50).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[A-Za-z ]*$").WithMessage("{ PropertyName} : Contiene Caracteres Invalidos (Solo acepta Letras y espacions)");

            RuleFor(d => d.CodigoPais)
                .NotNull().WithMessage("{PropertyName} : No debe ser NULL")
                .NotEmpty().WithMessage("{PropertyName} : No debe estar Vacia")
                .Length(1, 4).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[+0-9]*$").WithMessage("{ PropertyName} : Contiene Caracteres Invalidos (Solo acepta '+' y numeros)");

            RuleFor(d => d.Numero)
                .NotNull().WithMessage("{PropertyName} : No debe ser NULL")
                .NotEmpty().WithMessage("{PropertyName} : No debe estar Vacia")
                .Length(3, 50).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[0-9]{3}[-][0-9]{3}[-][0-9]{2}[-][0-9]{2}$").WithMessage("{ PropertyName } : Contiene Caracteres Invalidos (Solo acepta Letras y espacions)");
        }
    }
}
