using FluentValidation;

namespace Application.Features.SysDominiosCorreos.Commands.InsertarSysDominiosCorreosCommand
{
    public class InsertarSysDominioCorreoValidator : AbstractValidator<InsertarSysDominioCorreoCommand>
    {
        public InsertarSysDominioCorreoValidator()
        {
            RuleFor(s => s.Estatus)
               .NotNull().WithMessage("'{PropertyName}' : No debe ser NULL")
               .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
               .Length(1, 1).WithMessage("'{PropertyName}' : Solo acepta un Caracter");

            RuleFor(d => d.Dominio)
                .NotNull().WithMessage("{PropertyName} : No debe ser NULL")
                .NotEmpty().WithMessage("{PropertyName} : No debe estar Vacia")
                .Length(3, 80).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z0-9._/s-]*$").WithMessage("{PropertyName} : Contiene Caracteres Invalidos (Solo acepta letras mayusculas/Minusculas,Numeros,- ,_)");
        }
    }
}
