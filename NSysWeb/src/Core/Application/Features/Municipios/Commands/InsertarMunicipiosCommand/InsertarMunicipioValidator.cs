using FluentValidation;

namespace Application.Features.Municipios.Commands.InsertarMunicipiosCommand
{
    public class InsertarMunicipioValidator : AbstractValidator<InsertarMunicipioCommand>
    {
        public InsertarMunicipioValidator()
        {
            RuleFor(t => t.IdEstado)
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
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,/s 0-9]*$").WithMessage("'{PropertyName}' : Solo Letras, Numeros, Espacios");

            RuleFor(n => n.Abreviatura)
                //.NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(2, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z.]*$").WithMessage("'{PropertyName}' : Solo Letras");

            RuleFor(a => a.Clave)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo");
            // .Length(3, 3).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Numeros (ej. 001)")
            // .Matches(@"^[0-9]{3}$").WithMessage("'{PropertyName}' : Solo acepta Numeros (001)");

            RuleFor(c => c.Ciudad)
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(5, 80).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z()áéíóúñÑ .]*$").WithMessage("'{PropertyName}' : Solo Letras, Espacios y Puntos");
        }
    }
}
