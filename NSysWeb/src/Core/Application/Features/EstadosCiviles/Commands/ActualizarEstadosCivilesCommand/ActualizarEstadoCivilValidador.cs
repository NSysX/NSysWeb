using FluentValidation;

namespace Application.Features.EstadosCiviles.Commands.ActualizarEstadosCivilesCommand
{
    public class ActualizarEstadoCivilValidador : AbstractValidator<ActualizarEstadoCivilCommand>
    {
        public ActualizarEstadoCivilValidador()
        {
            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .Empty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^([A-Za-z0-9])$").WithMessage("'{PropertyName}' : Solo acepta numero y letras (Mayusculas / Minusculas)");

            RuleFor(x => x.Descripcion)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .Empty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,\s]*$|^[\W]*$").WithMessage("{PropertyName} : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,espacios Y /)");
        }
    }
}
