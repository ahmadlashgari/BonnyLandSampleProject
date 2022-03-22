using BL.Framework.Persistence.MongoDB;

namespace BL.Sample.Infrastructure.Persistence
{
    public class MongoReadRepositoryBase<T> : MongoReadRepository<T> where T : class, IAggregateRoot
    {
    }
}
