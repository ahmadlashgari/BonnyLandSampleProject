using Ardalis.Specification;
using System.Linq;
using EntityModel = BL.Sample.Domain.Entities.Entity;

namespace BL.Sample.ApplicationServices.Entity.Specifications.GetEntityById
{
    public class GetEntityByIdSpec : Specification<EntityModel>
    {
        public GetEntityByIdSpec(int id)
        {
            Query.Where(e => e.Id == id && e.Active && !e.IsDeleted);
        }
    }
}
