using FluentValidation;

namespace Application.Features.Nacionalidades.Commands.ActualizarNacionalidadesCommand
{
    public class ActualizarNacionalidadValidator : AbstractValidator<ActualizarNacionalidadCommand>
    {
        public ActualizarNacionalidadValidator()
        {
            RuleFor(c => c.IdNacionalidad)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^([A-Za-z0-9])$").WithMessage("'{PropertyName}' : Solo acepta numero y letras (Mayusculas / Minusculas)");

            RuleFor(x => x.Descripcion)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,\s]*$|^[\W]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,espacios Y /)");
        }
    }
}
