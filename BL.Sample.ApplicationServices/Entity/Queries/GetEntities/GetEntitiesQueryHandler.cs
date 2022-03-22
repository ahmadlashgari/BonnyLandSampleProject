using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using BL.Sample.ApplicationServices.Entity.Specifications.GetEntities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.Entity.Queries.GetEntities
{
    public class GetEntitiesQueryHandler : IRequestHandler<GetEntitiesQuery, Result<List<EntityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IEntityService _entityService;

        public GetEntitiesQueryHandler(IMapper mapper, IEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<List<EntityDto>>> Handle(GetEntitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _entityService.FindAllBySpecAsync(new GetEntitiesSpec());

            return Result<List<EntityDto>>.Success(_mapper.Map<List<EntityDto>>(result));
        }
    }
}
