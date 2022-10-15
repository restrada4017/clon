using MediatR;

namespace ADN.Application.Features.Adns.Commands.CreateAdn
{
    public class CreateAdnCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Adn1 { get; set; } = string.Empty;
        public bool IsClon { get; set; }
    }
}
