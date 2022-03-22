using Ardalis.Result.AspNetCore;
using BL.Sample.ApplicationServices.Common.Models;
using BL.Sample.ApplicationServices.MongoEntity.Commands.AddMongoEntity;
using BL.Sample.ApplicationServices.MongoEntity.Queries.GetMongoEntities;
using BL.Sample.ApplicationServices.MongoEntity.Queries.GetMongoEntityById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MongoDbController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MongoDbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MongoEntityDto>>> Get()
        {
            var result = await _mediator.Send(new GetMongoEntitiesQuery());

            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MongoEntityDto>> Get(string id)
        {
            var result = await _mediator.Send(new GetMongoEntityByIdQuery(id));

            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<MongoEntityDto>> Post([FromBody] AddMongoEntityCommand entity)
        {
            var result = await _mediator.Send(entity);

            return this.ToActionResult(result);
        }
    }
}
