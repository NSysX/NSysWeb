using FluentValidation;

namespace Application.Features.Nacionalidades.Commands.EliminarNacionalidadesCommand
{
    internal class EliminarNacionalidadValidator : AbstractValidator<EliminarNacionalidadCommand>
    {
        public EliminarNacionalidadValidator()
        {
            RuleFor(i => i.IdNacionalidad)
                    .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                    .NotEmpty().WithMessage("'{PropertyName}' : No puede Estar Vacio")
                    .Must(EsPositivo).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }

        protected static bool EsPositivo(int id)
        {
            return id > 0;
        }
    }
}
