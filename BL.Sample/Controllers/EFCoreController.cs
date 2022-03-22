using Ardalis.Result.AspNetCore;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using BL.Sample.ApplicationServices.Entity.Commands.AddEntity;
using BL.Sample.ApplicationServices.Entity.Queries.GetEntities;
using BL.Sample.ApplicationServices.Entity.Queries.GetEntityById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EFCoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EFCoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntityDto>>> Get()
        {
            var result = await _mediator.Send(new GetEntitiesQuery());

            return this.ToActionResult(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EntityDto>> Get(int id)
        {
            var result = await _mediator.Send(new GetEntityByIdQuery(id));

            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<EntityDto>> Post([FromBody] AddEntityCommand entity)
        {
            var result = await _mediator.Send(entity);

            return this.ToActionResult(result);
        }
    }
}
