using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(c => c.Edad)
                .InclusiveBetween(18, 65)
                .WithMessage("La edad debe estar entre 18 y 65 años.");
        }
    }
}