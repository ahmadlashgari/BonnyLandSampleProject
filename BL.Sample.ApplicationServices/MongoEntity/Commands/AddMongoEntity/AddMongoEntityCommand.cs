using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;

namespace BL.Sample.ApplicationServices.MongoEntity.Commands.AddMongoEntity
{
    public class AddMongoEntityCommand : IRequest<Result<MongoEntityDto>>
    {
        public string Name { get; set; }
    }
}
