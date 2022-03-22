using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;

namespace BL.Sample.ApplicationServices.Entity.Queries.GetEntityById
{
    public class GetEntityByIdQuery : IRequest<Result<EntityDto>>
    {
        public int Id { get; set; }

        public GetEntityByIdQuery(int id)
        {
            Id = id;
        }
    }
}
