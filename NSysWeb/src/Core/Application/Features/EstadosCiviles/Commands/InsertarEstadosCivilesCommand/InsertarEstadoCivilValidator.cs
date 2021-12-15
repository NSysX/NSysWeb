using FluentValidation;

namespace Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand
{
    public class InsertarEstadoCivilValidator : AbstractValidator<InsertarEstadoCivilCommand>
    {
        public InsertarEstadoCivilValidator()
        {
            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo acepta un Caracter");

            RuleFor(d => d.Descripcion)
                .NotNull().WithMessage("{PropertyName} : No debe ser NULL")
                .NotEmpty().WithMessage("{PropertyName} : No debe estar Vacia")
                .Length(3, 35).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,/s @]*$|^[\W]*$").WithMessage("{PropertyName} : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,espacios Y /)");
        }
    }
}
