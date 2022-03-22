using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System;

namespace BL.Sample.ApplicationServices.ElasticEntity.Queries.GetElasticEntityById
{
    public class GetElasticEntityByIdQuery : IRequest<Result<ElasticEntityDto>>
    {
        public Guid Id { get; private set; }

        public GetElasticEntityByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
