using FluentValidation;

namespace Application.Features.Asentamientos.Commands.ActualizarAsentamientosCommand
{
    public class ActualizarAsentamientoValidator : AbstractValidator<ActualizarAsentamientoCommand>
    {
        public ActualizarAsentamientoValidator()
        {
            RuleFor(t => t.IdAsentamientoTipo)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(t => t.IdMunicipio)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO")
                .Length(1).WithMessage("'{PropertyName}' : Solo debe tener una Letra")
                .Matches(@"[A-Za-z0-9]").WithMessage("'{PropertyName}' : Solo acepta Caracteres Alfanumericos");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(3, 100).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,/s 0-9]*$").WithMessage("'{PropertyName}' : Solo Letras, Numeros, Espacios");

            RuleFor(t => t.CodigoPostal)
               .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
               .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
