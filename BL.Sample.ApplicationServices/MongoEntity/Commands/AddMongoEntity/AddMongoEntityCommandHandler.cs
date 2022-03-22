using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MongoEntityModel = BL.Sample.Domain.Entities.MongoEntity;

namespace BL.Sample.ApplicationServices.MongoEntity.Commands.AddMongoEntity
{
    public class AddMongoEntityCommandHandler : IRequestHandler<AddMongoEntityCommand, Result<MongoEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoEntityService _entityService;

        public AddMongoEntityCommandHandler(IMapper mapper, IMongoEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<MongoEntityDto>> Handle(AddMongoEntityCommand request, CancellationToken cancellationToken)
        {
            var result = await _entityService.AddAsync(_mapper.Map<MongoEntityModel>(request), cancellationToken);

            return Result<MongoEntityDto>.Success(_mapper.Map<MongoEntityDto>(result));
        }
    }
}
