using ADN.Application.Contracts.Persistence;
using ADN.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Application.Features.Adns.Commands.CreateAdn
{
    public class CreateAdnCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAdnCommandHandler> _logger;

        public CreateAdnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateAdnCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAdnCommand request, CancellationToken cancellationToken)
        {
            var adnEntity = _mapper.Map<Adn>(request);
            _unitOfWork.AdnRepository.AddEntity(adnEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de adn");
            }

            _logger.LogInformation($"Adn {adnEntity.Id} fue creado existosamente");

            return adnEntity.Id;
        }
    }
}
