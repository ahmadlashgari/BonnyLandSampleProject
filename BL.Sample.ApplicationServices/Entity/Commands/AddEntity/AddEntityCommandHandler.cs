using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EntityModel = BL.Sample.Domain.Entities.Entity;

namespace BL.Sample.ApplicationServices.Entity.Commands.AddEntity
{
    public class AddEntityCommandHandler : IRequestHandler<AddEntityCommand, Result<EntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEntityService _entityService;

        public AddEntityCommandHandler(IMapper mapper, IEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<EntityDto>> Handle(AddEntityCommand request, CancellationToken cancellationToken)
        {
            var result = await _entityService.AddAsync(_mapper.Map<EntityModel>(request), cancellationToken);

            return Result<EntityDto>.Success(_mapper.Map<EntityDto>(result));
        }
    }
}
