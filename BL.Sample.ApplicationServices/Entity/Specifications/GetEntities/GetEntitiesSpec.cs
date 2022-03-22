using Ardalis.Specification;
using System.Linq;
using EntityModel = BL.Sample.Domain.Entities.Entity;

namespace BL.Sample.ApplicationServices.Entity.Specifications.GetEntities
{
    public class GetEntitiesSpec : Specification<EntityModel>
    {
        public GetEntitiesSpec()
        {
            Query.Where(e => e.Active && !e.IsDeleted);
        }
    }
}
