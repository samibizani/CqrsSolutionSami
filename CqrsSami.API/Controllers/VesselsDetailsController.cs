using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CqrsSami.Core.Exceptions;
using CqrsSami.Providers.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS.Domain.Models;

namespace CqrsSami.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselsDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VesselsDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VesselDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllVesselsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetIntersectionByVessel/{vessel_name}/{date}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetIntersectionByVessel(string vessel_name, DateTime date)
        {
            var query = new GetIntersectionByVesselQuery(vessel_name, date);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}