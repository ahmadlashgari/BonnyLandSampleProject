using BL.Framework.Persistence;
using BL.Framework.Persistence.EntityFrameworkCore;

namespace BL.Sample.Infrastructure.Persistence
{
    public class EFReadRepositoryBase<T> : EFReadRepository<T, BLDbContext> where T : class, IAggregateRoot
    {
        public EFReadRepositoryBase(BLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
