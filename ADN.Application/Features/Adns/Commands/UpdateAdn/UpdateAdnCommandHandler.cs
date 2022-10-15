using ADN.Application.Contracts.Persistence;
using ADN.Application.Exceptions;
using ADN.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ADN.Application.Features.Adns.Commands.UpdateAdn
{
    public class UpdateAdnCommandHandler : IRequestHandler<UpdateAdnCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAdnCommandHandler> _logger;

        public UpdateAdnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateAdnCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateAdnCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _unitOfWork.AdnRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                _logger.LogError($"No se encontro el adn id {request.Id}");
                throw new NotFoundException(nameof(Adn), request.Id);
            }

            _mapper.Map(request, streamerToUpdate, typeof(UpdateAdnCommand), typeof(Adn));
          
            _unitOfWork.AdnRepository.UpdateEntity(streamerToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el adn {request.Id}");

            return Unit.Value;
        }
    }
}
