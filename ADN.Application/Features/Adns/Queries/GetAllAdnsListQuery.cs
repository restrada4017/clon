using MediatR;

namespace ADN.Application.Features.Adns.Queries
{
    public class GetAllAdnsListQuery : IRequest<List<AdnVm>>
    {
        public GetAllAdnsListQuery()
        {
        }
    }
}
