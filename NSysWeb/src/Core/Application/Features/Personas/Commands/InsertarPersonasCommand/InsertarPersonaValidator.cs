using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Personas.Commands.InsertarPersonasCommand
{
    public class InsertarPersonaValidator : AbstractValidator<InsertarPersonaCommand>
    {
        public InsertarPersonaValidator()
        {
           // RuleFor()
        }
    }
}
