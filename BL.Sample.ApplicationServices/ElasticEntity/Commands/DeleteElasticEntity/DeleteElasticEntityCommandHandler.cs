using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElasticEntityModel = BL.Sample.Domain.Entities.ElasticEntity;

namespace BL.Sample.ApplicationServices.ElasticEntity.Commands.DeleteElasticEntity
{
    public class DeleteElasticEntityCommandHandler : IRequestHandler<DeleteElasticEntityCommand, Result<ElasticEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IElasticEntityService _entityService;

        public DeleteElasticEntityCommandHandler(IMapper mapper, IElasticEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<ElasticEntityDto>> Handle(DeleteElasticEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _entityService.FindByIdAsync(request.Id);

            if (!entity.IsValid || !entity.Documents.Any())
            {
                return Result<ElasticEntityDto>.NotFound();
            }

            await _entityService.DeleteAsync(entity.Documents.First(), cancellationToken);

            return Result<ElasticEntityDto>.Success(_mapper.Map<ElasticEntityDto>(entity.Documents.First()));
        }
    }
}
