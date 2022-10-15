using ADN.Application.Contracts.Persistence;
using ADN.Application.Exceptions;
using ADN.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ADN.Application.Features.Adns.Commands.DeleteAdn
{
    public class DeleteAdnCommandHandler : IRequestHandler<DeleteAdnCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteAdnCommandHandler> _logger;

        public DeleteAdnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteAdnCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteAdnCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _unitOfWork.AdnRepository.GetByIdAsync(request.Id);
            if (streamerToDelete == null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Adn), request.Id);      
            }

            _unitOfWork.AdnRepository.DeleteEntity(streamerToDelete);

            await _unitOfWork.Complete();
           
            _logger.LogInformation($"El {request.Id} streamer fue eliminado con exito");

            return Unit.Value;
        }
    }
}
