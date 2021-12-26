using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorreosElectronicos.Commands.EliminarCorreosElectronicosCommand
{
    public class EliminarCorreoElectronicoValidator : AbstractValidator<EliminarCorreoElectronicoCommand>
    {
        public EliminarCorreoElectronicoValidator()
        {
            RuleFor(i => i.IdCorreoElectronico)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }
    }
}
