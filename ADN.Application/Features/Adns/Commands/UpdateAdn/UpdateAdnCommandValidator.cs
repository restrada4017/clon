using FluentValidation;

namespace ADN.Application.Features.Adns.Commands.UpdateAdn
{
    public class UpdateAdnCommandValidator : AbstractValidator<UpdateAdnCommand>
    {
        public UpdateAdnCommandValidator()
        {
            RuleFor(p => p.Adn1)
                .NotEmpty().WithMessage("El adn No puede ser vacio")
                .NotNull().WithMessage("El valor no puede ser Nulo");
        }
    }
}
