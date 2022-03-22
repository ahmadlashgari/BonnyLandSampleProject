using Ardalis.Result.AspNetCore;
using BL.Sample.ApplicationServices.Common.Models;
using BL.Sample.ApplicationServices.ElasticEntity.Commands.AddElasticEntity;
using BL.Sample.ApplicationServices.ElasticEntity.Commands.DeleteElasticEntity;
using BL.Sample.ApplicationServices.ElasticEntity.Commands.UpdateElasticEntity;
using BL.Sample.ApplicationServices.ElasticEntity.Queries.GetElasticEntities;
using BL.Sample.ApplicationServices.ElasticEntity.Queries.GetElasticEntityById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ElasticController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ElasticController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ElasticEntityDto>>> Get()
        {
            var result = await _mediator.Send(new GetElasticEntitiesQuery());

            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElasticEntityDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetElasticEntityByIdQuery(id));

            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<ElasticEntityDto>> Post([FromBody] AddElasticEntityCommand entity)
        {
            var result = await _mediator.Send(entity);

            return this.ToActionResult(result);
        }

        [HttpPut]
        public async Task<ActionResult<ElasticEntityDto>> Put([FromBody] UpdateElasticEntityCommand entity)
        {
            var result = await _mediator.Send(entity);

            return this.ToActionResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ElasticEntityDto>> Delete([FromBody] DeleteElasticEntityCommand entity)
        {
            var result = await _mediator.Send(entity);

            return this.ToActionResult(result);
        }
    }
}
