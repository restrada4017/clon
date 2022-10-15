using ADN.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace ADN.Application.Features.Adns.Queries
{
    public class GetAllAdnsListQueryHandler : IRequestHandler<GetAllAdnsListQuery, List<AdnVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAdnsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AdnVm>> Handle(GetAllAdnsListQuery request, CancellationToken cancellationToken)
        {

            var adnList = await _unitOfWork.AdnRepository.GetAllAsync();
            return _mapper.Map<List<AdnVm>>(adnList);
        }

    }
}
