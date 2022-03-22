using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElasticEntityModel = BL.Sample.Domain.Entities.ElasticEntity;

namespace BL.Sample.ApplicationServices.ElasticEntity.Commands.UpdateElasticEntity
{
    public class UpdateElasticEntityCommandHandler : IRequestHandler<UpdateElasticEntityCommand, Result<ElasticEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IElasticEntityService _entityService;

        public UpdateElasticEntityCommandHandler(IMapper mapper, IElasticEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<ElasticEntityDto>> Handle(UpdateElasticEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _entityService.FindByIdAsync(request.Id);

            if (!entity.IsValid || !entity.Documents.Any())
            {
                return Result<ElasticEntityDto>.NotFound();
            }

            var result = await _entityService.UpdateAsync(_mapper.Map<ElasticEntityModel>(request), cancellationToken);

            if (!result.IsValid)
            {
                return Result<ElasticEntityDto>.Error("Update Entity in index failed");
            }

            entity = await _entityService.FindByIdAsync(request.Id);

            return Result<ElasticEntityDto>.Success(_mapper.Map<ElasticEntityDto>(entity.Documents.First()));
        }
    }
}
