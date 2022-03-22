using BL.Framework.Persistence.MongoDB;

namespace BL.Sample.Infrastructure.Persistence
{
    public class MongoRepositoryBase<T> : MongoRepository<T> where T : class, IAggregateRoot
    {
    }
}
