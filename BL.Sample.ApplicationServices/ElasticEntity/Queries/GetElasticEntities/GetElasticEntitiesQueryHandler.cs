using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.ElasticEntity.Queries.GetElasticEntities
{
    public class GetElasticEntitiesQueryHandler : IRequestHandler<GetElasticEntitiesQuery, Result<List<ElasticEntityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IElasticEntityService _entityService;

        public GetElasticEntitiesQueryHandler(IMapper mapper, IElasticEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<List<ElasticEntityDto>>> Handle(GetElasticEntitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _entityService.FindAllAsync();

            if (!result.IsValid)
            {
                return Result<List<ElasticEntityDto>>.Error("Fetch Entities from index failed");
            }

            return Result<List<ElasticEntityDto>>.Success(_mapper.Map<List<ElasticEntityDto>>(result.Documents));
        }
    }
}
