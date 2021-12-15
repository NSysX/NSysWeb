using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SysDominiosCorreos.Commands.EliminarSysDominiosCorreosCommand
{
    public class EliminarSysDominioCorreoValidator : AbstractValidator<EliminarSysDominioCorreoCommand>
    {
        public EliminarSysDominioCorreoValidator()
        {
            RuleFor(i => i.IdSysDominio)
                    .NotNull().WithMessage("'{PropertyName}' : No puede ser Nulo")
                    .NotEmpty().WithMessage("'{PropertyName}' : No puede Estar Vacio")
                    .Must(EsPositivo).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");
        }

        protected static bool EsPositivo(int id) => id > 0;

    }
}
