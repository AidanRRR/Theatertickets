using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Repositories;
using backend.Domain.Features.Voorstelling;
using backend.Domain.Features.Voorstelling.GET;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VoorstellingController : Controller
    {
        public ITheaterTicketsRepository TheaterTicketsRepository { get; }
        public IMediator _mediator { get; }

        public VoorstellingController(ITheaterTicketsRepository theaterTicketsRepository, IMediator mediator)
        {
            TheaterTicketsRepository = theaterTicketsRepository;
            _mediator = mediator;
        }

        [HttpPost("AddVoorstelling")]
        public async Task<IActionResult> AddVoorstelling([FromBody] AddVoorstelling.Request request)
        {
            var mdl = await _mediator.Send(request);
            if (mdl != null)
            {
                return Ok(mdl);
            }
            else
            {
                return NotFound(mdl.ErrorMessages);
            }
        }

        [HttpGet("GetAllVoorstellingen")]
        public async Task<IActionResult> GetAllVoorstellingen([FromBody] GetVoorstellingen.Request request)
        {
            var mdl = await _mediator.Send(request);
            if (mdl != null)
            {
                return Ok(mdl);
            }
            else
            {
                return NotFound(mdl.ErrorMessages);
            }
        }

        [HttpPut("UpdateVoorstelling")]
        public async Task<IActionResult> UpdateVoorstelling([FromBody] UpdateVoorstelling.Request request)
        {
            var mdl = await _mediator.Send(request);
            if (mdl != null)
            {
                return Ok(mdl);
            }
            else
            {
                return NotFound(mdl.ErrorMessages);
            }
        }
    }
}