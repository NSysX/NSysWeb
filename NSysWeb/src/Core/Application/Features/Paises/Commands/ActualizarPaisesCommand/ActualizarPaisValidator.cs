﻿using FluentValidation;

namespace Application.Features.Paises.Commands.ActualizarPaisesCommand
{
    public class ActualizarPaisValidator : AbstractValidator<ActualizarPaisCommand>
    {
        public ActualizarPaisValidator()
        {
            RuleFor(x => x.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(1, 1).WithMessage("'{PropertyName}' : Solo debe tener un caracter Alfanumerico")
                .Matches(@"^[A-Za-z0-9]$").WithMessage("'{PropertyName}' : Solo Acepta caracteres Alfanumericos");

            RuleFor(n => n.Nombre)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacia")
                .NotNull().WithMessage("'{PropertyName}' : No debe se Nulo")
                .Length(3, 20).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres longitud")
                .Matches(@"^[A-Za-záéíóú. ]*$").WithMessage("'{PropertyName}' : Solo Caracteres Alfanumericos");

            RuleFor(a => a.Abreviatura)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                .NotNull().WithMessage("'{PrpertyName}' : No debe ser Nulo")
                .Length(2, 5).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                .Matches(@"^[A-Za-záéíóú. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");
        }
    }
}
