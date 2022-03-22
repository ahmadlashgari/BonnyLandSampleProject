using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.ElasticEntity.Queries.GetElasticEntityById
{
    public class GetElasticEntityByIdQueryHandler : IRequestHandler<GetElasticEntityByIdQuery, Result<ElasticEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IElasticEntityService _entityService;

        public GetElasticEntityByIdQueryHandler(IMapper mapper, IElasticEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<ElasticEntityDto>> Handle(GetElasticEntityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _entityService.FindByIdAsync(request.Id);

            if (!result.IsValid)
            {
                return Result<ElasticEntityDto>.NotFound();
            }

            return Result<ElasticEntityDto>.Success(_mapper.Map<ElasticEntityDto>(result.Documents.SingleOrDefault()));
        }
    }
}
