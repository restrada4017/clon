using ADN.Domain.CustomEntities;
using ADN.Domain.Entities;
using ADN.Domain.Exceptions;
using ADN.Domain.Interfaces.Services;
using ADN.Shared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Adn.Helper;

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

        [HttpPost, Route("clon")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AdnDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> clon([FromBody] AdnRequest request)
        {
            try
            {
                var result = await _AdnService.IsClon(request.Adn);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "No es un clon");
                }
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
        }
    }
}
