using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace BL.Sample.ApplicationServices.MongoEntity.Queries.GetMongoEntities
{
    public class GetMongoEntitiesQuery : IRequest<Result<List<MongoEntityDto>>>
    {
    }
}
