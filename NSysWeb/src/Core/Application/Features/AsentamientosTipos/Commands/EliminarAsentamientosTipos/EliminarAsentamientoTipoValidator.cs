using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AsentamientosTipos.Commands.EliminarAsentamientosTipos
{
    public class EliminarAsentamientoTipoValidator : AbstractValidator<EliminarAsentamientoTipoCommand>
    {
        public EliminarAsentamientoTipoValidator()
        {
            RuleFor(i => i.IdAsentamientoTipo)
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
