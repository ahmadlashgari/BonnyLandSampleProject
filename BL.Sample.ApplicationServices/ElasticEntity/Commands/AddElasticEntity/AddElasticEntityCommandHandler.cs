using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElasticEntityModel = BL.Sample.Domain.Entities.ElasticEntity;

namespace BL.Sample.ApplicationServices.ElasticEntity.Commands.AddElasticEntity
{
    public class AddElasticEntityCommandHandler : IRequestHandler<AddElasticEntityCommand, Result<ElasticEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IElasticEntityService _entityService;

        public AddElasticEntityCommandHandler(IMapper mapper, IElasticEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<ElasticEntityDto>> Handle(AddElasticEntityCommand request, CancellationToken cancellationToken)
        {
            var result = await _entityService.AddAsync(_mapper.Map<ElasticEntityModel>(request), cancellationToken);

            if (!result.IsValid)
            {
                return Result<ElasticEntityDto>.Error("Add Entity to Index failed");
            }

            var entity = await _entityService.FindByIdAsync(Guid.Parse(result.Id));

            return Result<ElasticEntityDto>.Success(_mapper.Map<ElasticEntityDto>(entity.Documents.First()));
        }
    }
}
