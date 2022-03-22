using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;
using System;

namespace BL.Sample.ApplicationServices.ElasticEntity.Commands.DeleteElasticEntity
{
    public class DeleteElasticEntityCommand : IRequest<Result<ElasticEntityDto>>
    {
        public Guid Id { get; private set; }

        public DeleteElasticEntityCommand(Guid id)
        {
            Id = id;
        }
    }
}
