using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.MongoEntity.Queries.GetMongoEntities
{
    public class GetMongoEntitiesQueryHandler : IRequestHandler<GetMongoEntitiesQuery, Result<List<MongoEntityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoEntityService _entityService;

        public GetMongoEntitiesQueryHandler(IMapper mapper, IMongoEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<List<MongoEntityDto>>> Handle(GetMongoEntitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _entityService.FindAllAsync();

            return Result<List<MongoEntityDto>>.Success(_mapper.Map<List<MongoEntityDto>>(result));
        }
    }
}
