using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using System;

namespace BL.Sample.ApplicationServices.ElasticEntity.Commands.UpdateElasticEntity
{
    public class UpdateElasticEntityCommand : MediatR.IRequest<Result<ElasticEntityDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
