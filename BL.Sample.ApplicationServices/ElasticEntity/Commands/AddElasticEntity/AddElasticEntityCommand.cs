using Ardalis.Result;
using BL.Sample.ApplicationServices.Common.Models;

namespace BL.Sample.ApplicationServices.ElasticEntity.Commands.AddElasticEntity
{
    public class AddElasticEntityCommand : MediatR.IRequest<Result<ElasticEntityDto>>
    {
        public string Name { get; set; }
    }
}
