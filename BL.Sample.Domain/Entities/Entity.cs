using BL.Framework.Persistence.EntityFrameworkCore;

namespace BL.Sample.Domain.Entities
{
    public class Entity : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
