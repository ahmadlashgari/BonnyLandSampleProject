using Ardalis.Result;
using AutoMapper;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.ApplicationServices.MongoEntity.Queries.GetMongoEntityById
{
    public class GetMongoEntityByIdQueryHandler : IRequestHandler<GetMongoEntityByIdQuery, Result<MongoEntityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoEntityService _entityService;

        public GetMongoEntityByIdQueryHandler(IMapper mapper, IMongoEntityService entityService)
        {
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<Result<MongoEntityDto>> Handle(GetMongoEntityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _entityService.FindByIdAsync(request.Id);

            if (result == null)
            {
                return Result<MongoEntityDto>.NotFound();
            }

            return Result<MongoEntityDto>.Success(_mapper.Map<MongoEntityDto>(result));
        }
    }
}
