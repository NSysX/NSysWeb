using FluentValidation;

namespace Application.Features.SysDominiosCorreos.Commands.ActualizarSysDominiosCorreosCommand
{
    public class ActualizarSysDominioCorreoValidator : AbstractValidator<ActualizarSysDominioCorreoCommand>
    {
        public ActualizarSysDominioCorreoValidator()
        {
            RuleFor(i => i.IdSysDominioCorreo)
              .NotNull().WithMessage("'{PropertyName}' : No debe ser NULL")
              .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
              .Must(Positivo).WithMessage("'{PropertyName}' : Debe ser mayo a 0");

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

        protected static bool Positivo(int id) => id > 0;
    }
}
