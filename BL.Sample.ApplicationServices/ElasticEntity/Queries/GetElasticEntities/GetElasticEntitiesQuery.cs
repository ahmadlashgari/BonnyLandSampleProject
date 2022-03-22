using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace BL.Sample.ApplicationServices.ElasticEntity.Queries.GetElasticEntities
{
    public class GetElasticEntitiesQuery : IRequest<Result<List<ElasticEntityDto>>>
    {
    }
}
