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
    [Route("api/Adn")]
    [ApiController]
    public class AdnController : ControllerBase
    {
        private readonly IAdnService _AdnService;
        private readonly IMapper _mapper;

        public AdnController(IAdnService adnService, IMapper mapper)
        {
            _AdnService = adnService;
            _mapper = mapper;
        }

        [HttpGet, Route("GetAll")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AdnDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _AdnService.GetAll();
                var listDto = _mapper.Map<IEnumerable<AdnDto>>(list);
                return Ok(listDto);
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
        }
    }
}
