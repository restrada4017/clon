using FluentValidation;

namespace ADN.Application.Features.Adns.Commands.CreateAdn
{
    public class CreateAdnCommandValidator : AbstractValidator<CreateAdnCommand>
    {
        public CreateAdnCommandValidator()
        {
            RuleFor(p => p.Adn1)
                .NotEmpty().WithMessage("El adn No puede ser vacio")
                .NotNull().WithMessage("El valor no puede ser Nulo");
        }
    }
}
