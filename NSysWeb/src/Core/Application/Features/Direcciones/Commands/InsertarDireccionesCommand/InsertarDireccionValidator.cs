using FluentValidation;

namespace Application.Features.Direcciones.Commands.InsertarDireccionesCommand
{
    public class InsertarDireccionValidator : AbstractValidator<InsertarDireccionCommand>
    {
        public InsertarDireccionValidator()
        {
            RuleFor(t => t.IdAsentamiento)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO")
                .Length(1).WithMessage("'{PropertyName}' : Solo debe tener una Letra")
                .Matches(@"[A-Za-z0-9]").WithMessage("'{PropertyName}' : Solo acepta Caracteres Alfanumericos");

            RuleFor(a => a.Calle)
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                 .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.EntreLaCalle)
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                 .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.YlaCalle)
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                 .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.NumeroExterior)
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                 .Length(1, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z0-9-]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.NumeroInterior)
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                 .Length(1, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z0-9-]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(l => l.Latitud)
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .LessThan(-90).WithMessage("'{PrpertyName}' : El Valor Maximo es {ComparisonValue}")
                .GreaterThan(90).WithMessage("'{PrpertyName}' : El Valor Maximo es {ComparisonValue}");

            RuleFor(l => l.Longitud)
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .LessThan(-180).WithMessage("'{PrpertyName}' : El Valor Maximo es {ComparisonValue}")
                .GreaterThan(180).WithMessage("'{PrpertyName}' : El Valor Maximo es {ComparisonValue}");

            RuleFor(e => e.Referencia)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO")
                .MaximumLength(250).WithMessage("'{PropertyName}' : Acepta un Maximo de {MaxLength}")
                .Matches(@"[A-Za-z0-9.\s]").WithMessage("'{PropertyName}' : Solo acepta Caracteres Alfanumericos");

            RuleFor(f => f.Foto)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .MaximumLength(250).WithMessage("'{PropertyName}' : No debe tener mas de {MaxLength} caracteres")
                .Matches(@"^[A-Za-z0-9:\\.]*$");

            RuleFor(f => f.EsFiscal)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio");
        }
    }
}
