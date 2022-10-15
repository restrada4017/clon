using ADN.Application.Features.Adns.Commands.CreateAdn;
using ADN.Application.Features.Adns.Commands.DeleteAdn;
using ADN.Application.Features.Adns.Commands.UpdateAdn;
using ADN.Application.Features.Adns.Queries;
using ADN.Domain.CustomEntities;
using ADN.Domain.Entities;
using ADN.Domain.Exceptions;
using ADN.Domain.Interfaces.Services;
using ADN.Shared.DTOs;
using AutoMapper;
using MediatR;
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
        private readonly IMediator _mediator;

        public AdnController(IAdnService adnService, IMapper mapper, IMediator mediator)
        {
            _AdnService = adnService;
            _mapper = mapper;
            _mediator = mediator;
        }


        #region mediator
        

        [HttpGet, Route("GetAllAdn")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AdnVm>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllAdn()
        {
            
                var query = new GetAllAdnsListQuery();
                var videos = await _mediator.Send(query);
                return Ok(videos);
           
        }

        [HttpPost, Route("CreateAdn")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAdn([FromBody] CreateAdnCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut, Route("UpdateAdn")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAdn([FromBody] UpdateAdnCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAdn")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAdn(int id)
        {
            var command = new DeleteAdnCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }


        #endregion


        [HttpPost, Route("clon")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AdnDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Clon([FromBody] AdnRequest request)
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

        [HttpGet, Route("estadisticas")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AdnDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Estadisticas()
        {
            

                ResponseStatistics response = new ResponseStatistics();

                response.contador_clon_adn = 0;
                response.contador_amigos_adn = 0;
                response.promedio = 0;

                var list = await _AdnService.GetAll();
                response.contador_clon_adn = list.Count(x => x.IsClon);
                response.contador_amigos_adn = list.Count(x => !x.IsClon);
                response.promedio = response.contador_clon_adn / response.contador_amigos_adn == 0 ? 1 : response.contador_amigos_adn;

                return Ok(response);
           
        }
    }
}
