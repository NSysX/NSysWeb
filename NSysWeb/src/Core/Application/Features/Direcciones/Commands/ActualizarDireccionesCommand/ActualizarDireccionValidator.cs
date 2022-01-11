using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Commands.ActualizarDireccionesCommand
{
    public class ActualizarDireccionValidator : AbstractValidator<ActualizarDireccionCommand>
    {
        public ActualizarDireccionValidator()
        {
            RuleFor(t => t.IdAsentamiento)
                   .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                   .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(e => e.Estatus)
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO")
                .Length(1).WithMessage("'{PropertyName}' : Solo debe tener una Letra")
                .Matches(@"[A-Za-z0-9]").WithMessage("'{PropertyName}' : Solo acepta Caracteres Alfanumericos");

            RuleFor(a => a.Calle)
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                 .Length(3, 150).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[a-zA-ZáéíóúñÑ. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.EntreLaCalle)
                 .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                 //.NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .MaximumLength(100).WithMessage("'{PropertyName}' : No debe tener mas de {MaxLength} Letras / espacios")
                 .Matches(@"^[a-zA-ZáéíóúñÑ. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.YlaCalle)
                 .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                 //.NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .MaximumLength(100).WithMessage("'{PropertyName}' : No Debe tener mas de {MaxLength} Letras / espacios")
                 .Matches(@"^[a-zA-ZáéíóúñÑ. ]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.NumeroExterior)
                 .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio, Default('SN')")
                 .Length(1, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z0-9-]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(a => a.NumeroInterior)
                 .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                 .NotEmpty().WithMessage("'{PropertyName}' : No debe estar vacio")
                 .Length(1, 10).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Letras")
                 .Matches(@"^[A-Z0-9-]*$").WithMessage("'{PropertyName}' : Solo acepta letras y puntos");

            RuleFor(l => l.Latitud)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .Must(EstaEnRangoLatitud).WithMessage("'{PropertyName}' : El Valor Minimo = -90.0000000 y el Maximo = 90.0000000");

            RuleFor(l => l.Longitud)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .Must(EstaEnRangoLongitud).WithMessage("'{PropertyName}' : El Valor Minimo = -180.0000000 y el Maximo = 180.0000000");

            RuleFor(e => e.Referencia)
                .NotNull().WithMessage("'{PropertyName}' : No debe se NULO")
                //.NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio")
                .MaximumLength(250).WithMessage("'{PropertyName}' : Acepta un Maximo de {MaxLength}")
                .Matches(@"^[a-zA-ZáéíóúñÑ. ]*$").WithMessage("'{PropertyName}' : Solo acepta Caracteres Alfanumericos");

            RuleFor(f => f.Foto)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .MaximumLength(250).WithMessage("'{PropertyName}' : No debe tener mas de {MaxLength} caracteres")
                .Matches(@"^[A-Za-z0-9:\\.]*$");

            RuleFor(f => f.EsFiscal)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .NotEmpty().WithMessage("'{PropertyName}' : No debe ser Vacio");
        }

        protected static bool EstaEnRangoLatitud(double latitud)
        {
            if (latitud <= -90.0000000 || latitud >= 90.0000000)
            {
                return false;
            }
            return true;
        }

        protected static bool EstaEnRangoLongitud(double longitud)
        {
            if (longitud <= -180.0000000 || longitud >= 180.0000000)
            {
                return false;
            }
            return true;
        }
    }
}
