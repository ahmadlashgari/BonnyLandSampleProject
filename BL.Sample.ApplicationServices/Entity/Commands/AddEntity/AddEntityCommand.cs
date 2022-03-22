using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;
using MediatR;

namespace BL.Sample.ApplicationServices.Entity.Commands.AddEntity
{
    public class AddEntityCommand : IRequest<Result<EntityDto>>
    {
        public string Name { get; set; }
    }
}
