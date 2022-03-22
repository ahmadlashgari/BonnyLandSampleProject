using BL.Framework.Persistence;
using BL.Framework.Persistence.EntityFrameworkCore;

namespace BL.Sample.Infrastructure.Persistence
{
    public class EFRepositoryBase<T> : EFRepository<T, BLDbContext> where T : class, IAggregateRoot
    {
        public EFRepositoryBase(BLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
