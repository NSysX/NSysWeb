using FluentValidation;

namespace Application.Features.DocumentosTipos.Commands.InsertarDocumentosTiposCommand
{
    public class InsertarDocumentoTipoValidator : AbstractValidator<InsertarDocumentoTipoCommand>
    {
        public InsertarDocumentoTipoValidator()
        {
            RuleFor(x => x.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo debe tener un caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]$").WithMessage("'{PropertyName}' : Solo Acepta caracteres Alfanumericos");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(5, 50).WithMessage("'{PropertyName}' : No debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,/s @]*$|^[\W]*$").WithMessage("'{PropertyName}' : Solo Caracteres Alfanumericos");

            RuleFor(a => a.Abreviatura)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(3, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(l => l.Longitud)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .Must(longitudValida).WithMessage("'{PropertyName}' : Longitud debe ser mayor a 0 y menor a 30");
        }

        protected static bool longitudValida(int longitud)
        {
            return !(longitud <= 0 || longitud > 30);
        }
    }
}
