using FluentValidation;

namespace Application.Features.Estados.Commands.ActualizarEstadosCommand
{
    public class ActualizarEstadoValidator : AbstractValidator<ActualizarEstadoCommand>
    {
        public ActualizarEstadoValidator()
        {
            RuleFor(i => i.IdEstado)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(x => x.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo debe tener un caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]$").WithMessage("'{PropertyName}' : Solo Acepta caracteres Alfanumericos");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(5, 20).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,/s @]*$|^[\W]*$").WithMessage("'{PropertyName}' : Solo Caracteres Alfanumericos");

            RuleFor(a => a.VariableAbrev)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Za-záéíóú. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.RenapoAbrev)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(2, 2).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Za-záéíóú. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.TresDigitosAbrev)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(3, 3).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Za-záéíóú. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.Clave)
                //.NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo");
               // .Length(3, 3).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Numeros (ej. 001)")
               // .Matches(@"^[0-9]{3}$").WithMessage("'{PropertyName}' : Solo acepta Numeros (001)");
        }
    }
}
