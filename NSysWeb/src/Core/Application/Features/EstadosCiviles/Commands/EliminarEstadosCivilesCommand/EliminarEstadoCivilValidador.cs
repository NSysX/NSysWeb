using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand
{
    public class EliminarEstadoCivilValidador : AbstractValidator<EliminarEstadoCivilCommand>
    {
        public EliminarEstadoCivilValidador()
        {
            RuleFor(i => i.IdEstadoCivil)
                .NotEmpty().WithMessage("'{PropertyName}' : No Debe Ser Vacio")
                .Must(SoloNumeros);
        }

        private protected static bool SoloNumeros(int id)
        {
            return Regex.IsMatch(id.ToString(), @"^[1-9]*$");
        }
    }
}
