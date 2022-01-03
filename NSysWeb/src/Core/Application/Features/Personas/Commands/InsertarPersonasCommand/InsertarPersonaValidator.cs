using FluentValidation;
using System;

namespace Application.Features.Personas.Commands.InsertarPersonasCommand
{
    public class InsertarPersonaValidator : AbstractValidator<InsertarPersonaCommand>
    {
        public InsertarPersonaValidator()
        {
            RuleFor(c => c.IdNacionalidad)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .GreaterThan(0).WithMessage("'{PropertyName}' : El Id debe ser Mayor a Cero");

            RuleFor(c => c.IdEstadoCivil)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .GreaterThan(0).WithMessage("'{PropertyName}' : el Id debe ser Mayor a Cero");

            RuleFor(s => s.Estatus)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^([A-Za-z0-9])$").WithMessage("'{PropertyName}' : Solo acepta numero y letras (Mayusculas / Minusculas)");

            RuleFor(x => x.ApellidoPaterno)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-ZáéíóúñÑ\s]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,Minusculas y espacios)");

            RuleFor(x => x.ApellidoMaterno)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(5, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-ZáéíóúñÑ\s]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,Minusculas y espacios)");

            RuleFor(x => x.Nombres)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(2, 50).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[a-zA-ZáéíóúñÑ\s]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta letras mayusculas,Minusculas y espacios)");

            RuleFor(f => f.FechaNacimiento)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Must(FechaNacimeinto => FechaNacimeinto != default(DateTime)).WithMessage("'{PropertyName}' : Fecha Invalida");

            RuleFor(f => f.Foto)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser NULO")
                .MaximumLength(250).WithMessage("'{PropertyName}' : No debe tener mas de {MaxLength} caracteres")
                .Matches(@"^[A-Za-z0-9:\\.]*$");

            RuleFor(s => s.Sexo)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL")
                .NotEmpty().WithMessage("'{PropertyName}' : No puede estar vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' : Debe tener entre {MinLength} y {MaxLength} Caracteres")
                .Matches(@"^[F]|[M]*$").WithMessage("'{PropertyName}' : Contiene Caracteres Invalidos (Solo acepta M = Masculino y F = Femenino)");

            RuleFor(n => n.Notas)
                .NotNull().WithMessage("'{PropertyName}' : No puede ser NULL");
        }
    }
}
