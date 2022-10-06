using ADN.Domain.Entities;
using ADN.Domain.Exceptions;
using ADN.Domain.Interfaces.Services;
using ADN.Shared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Adn.Controllers
{
    [Produces("application/json")]
    [Route("api/Estadistica")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        private readonly IEstadisticaService _EstadisticaService;
        private readonly IMapper _mapper;

        public EstadisticaController(IEstadisticaService estadisticaService, IMapper mapper)
        {
            _EstadisticaService = estadisticaService;
            _mapper = mapper;
        }

        [HttpGet, Route("GetAll")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<EstadisticaDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _EstadisticaService.GetAll();
                var listDto = _mapper.Map<IEnumerable<EstadisticaDto>>(list);
                return Ok(listDto);
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
        }
    }
}

