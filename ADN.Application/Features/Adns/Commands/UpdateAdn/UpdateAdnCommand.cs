using MediatR;

namespace ADN.Application.Features.Adns.Commands.UpdateAdn
{
    public  class UpdateAdnCommand : IRequest 
    {
        public int Id { get; set; }
        public string Adn1 { get; set; } = string.Empty;
        public bool IsClon { get; set; }
    }
}
