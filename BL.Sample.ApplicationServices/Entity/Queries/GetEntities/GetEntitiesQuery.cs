using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace BL.Sample.ApplicationServices.Entity.Queries.GetEntities
{
    public class GetEntitiesQuery : IRequest<Result<List<EntityDto>>>
    {
    }
}
