﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorreosElectronicos.Commands.InsertarCorreosElectronicosCommand
{
    public class InsertarCorreoElectronicoValidator : AbstractValidator<InsertarCorreoElectronicoCommand>
    {
        public InsertarCorreoElectronicoValidator()
        {
            RuleFor(x => x.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo debe tener un caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]$").WithMessage("'{PropertyName}' : Solo Acepta caracteres Alfanumericos");

            RuleFor(c => c.Correo)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(5, 50).WithMessage("'{PropertyName}' : No debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .EmailAddress().WithMessage("Ingresar un Correo Valido");

            RuleFor(d => d.TipoCorreo)
                .NotNull().WithMessage("{PropertyName} : No debe ser NULL")
                .NotEmpty().WithMessage("{PropertyName} : No debe estar Vacia")
                .Length(3, 50).WithMessage("{PropertyName} : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[A-Za-z ]*$").WithMessage("{ PropertyName} : Contiene Caracteres Invalidos (Solo acepta Letras y espacions)");
        }
    }
}
