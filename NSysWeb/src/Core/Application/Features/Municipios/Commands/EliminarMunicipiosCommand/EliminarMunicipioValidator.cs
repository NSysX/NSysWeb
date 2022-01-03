using FluentValidation;

namespace Application.Features.Municipios.Commands.EliminarMunicipiosCommand
{
    public class EliminarMunicipioValidator : AbstractValidator<EliminarMunicipioCommand>
    {
        public EliminarMunicipioValidator()
        {
            RuleFor(i => i.IdMunicipio)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
