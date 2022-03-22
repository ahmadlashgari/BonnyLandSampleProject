using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;

namespace BL.Sample.ApplicationServices.MongoEntity.Queries.GetMongoEntityById
{
    public class GetMongoEntityByIdQuery : IRequest<Result<MongoEntityDto>>
    {
        public string Id { get; set; }

        public GetMongoEntityByIdQuery(string id)
        {
            Id = id;
        }
    }
}
