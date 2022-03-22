using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.Entity.Queries.GetEntityById
{
    public class GetEntityByIdQueryHandler : IRequestHandler<GetEntityByIdQuery, Result<EntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEntityService _entityService;

        public GetEntityByIdQueryHandler(IMapper mapper, IEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<EntityDto>> Handle(GetEntityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _entityService.FindByIdAsync(request.Id);

            if (result == null)
            {
                return Result<EntityDto>.NotFound();
            }

            return Result<EntityDto>.Success(_mapper.Map<EntityDto>(result));
        }
    }
}
