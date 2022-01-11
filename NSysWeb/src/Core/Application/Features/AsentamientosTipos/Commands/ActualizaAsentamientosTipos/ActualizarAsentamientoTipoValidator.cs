using FluentValidation;

namespace Application.Features.AsentamientosTipos.Commands.ActualizaAsentamientosTipos
{
    public class ActualizarAsentamientoTipoValidator : AbstractValidator<ActualizarAsentamientoTipoCommand>
    {
        public ActualizarAsentamientoTipoValidator()
        {
            RuleFor(i => i.IdAsentamientoTipo)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(1, 1).WithMessage("'{PropertyName}' : Longitud de 1 caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]{1}$").WithMessage("'{PropertyName}' : Solo Acepta un caracter Alfanumerico");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .Length(3, 50).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres");

            RuleFor(a => a.Abreviatura)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(1, 5).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");
        }
    }
}
