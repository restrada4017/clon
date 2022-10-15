using MediatR;

namespace ADN.Application.Features.Adns.Commands.DeleteAdn
{
    public class DeleteAdnCommand : IRequest
    {
        public int Id { get; set; }
    }
}
