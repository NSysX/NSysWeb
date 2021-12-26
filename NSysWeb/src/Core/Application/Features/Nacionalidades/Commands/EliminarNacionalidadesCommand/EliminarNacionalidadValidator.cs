using FluentValidation;

namespace Application.Features.Nacionalidades.Commands.EliminarNacionalidadesCommand
{
    internal class EliminarNacionalidadValidator : AbstractValidator<EliminarNacionalidadCommand>
    {
        public EliminarNacionalidadValidator()
        {
            RuleFor(i => i.IdNacionalidad)
                    .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                    .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
