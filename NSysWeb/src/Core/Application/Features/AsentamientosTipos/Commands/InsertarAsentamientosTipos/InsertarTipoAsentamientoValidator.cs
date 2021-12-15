﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AsentamientosTipos.Commands.InsertarAsentamientosTipos
{
    public class InsertarTipoAsentamientoValidator : AbstractValidator<InsertarAsentamientoTipoCommand>
    {
        public InsertarTipoAsentamientoValidator()
        {
            RuleFor(x => x.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo debe tener un caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]$").WithMessage("'{PropertyName}' : Solo Acepta caracteres Alfanumericos");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(5, 50).WithMessage("'{PropertyName}' : No debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[a-zA-Z()áéíóúñÑ.,/s @]*$|^[\W]*$").WithMessage("'{PropertyName}' : Solo Caracteres Alfanumericos");

            RuleFor(a => a.Abreviatura)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(1, 5).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Za-z.]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");
        }
    }
}
