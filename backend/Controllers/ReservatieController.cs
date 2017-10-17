using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Repositories;
using backend.Domain.Features.Reservatie;
using backend.Domain.Features.Reservatie.GET;
using backend.Domain.Features.Voorstelling;
using backend.Domain.Features.Voorstelling.GET;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReservatieController : Controller
    {
        public ITheaterTicketsRepository TheaterTicketsRepository { get; }
        public IMediator _mediator { get; }

        public ReservatieController(ITheaterTicketsRepository theaterTicketsRepository, IMediator mediator)
        {
            TheaterTicketsRepository = theaterTicketsRepository;
            _mediator = mediator;
        }

        [HttpPost("AddReservatie")]
        public async Task<IActionResult> AddReservatie([FromBody] AddReservatie.Request request)
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

        [HttpGet("GetAllReservaties")]
        public async Task<IActionResult> GetAllReservaties([FromBody] GetReservaties.Request request)
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

        [HttpGet("GetAllReservatiesByVoorstelling")]
        public async Task<IActionResult> GetAllReservatiesByVoorstelling([FromBody] GetReservatiesByVoorstelling.Request request)
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

        [HttpPut("UpdateReservatie")]
        public async Task<IActionResult> UpdateReservatie([FromBody] UpdateReservatie.Request request)
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