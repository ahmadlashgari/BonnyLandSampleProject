using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoEntityModel = BL.Sample.Domain.Entities.MongoEntity;

namespace BL.Sample.ApplicationServices.Common.Interfaces
{
    public interface IMongoEntityService
    {
        Task<List<MongoEntityModel>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<MongoEntityModel> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<MongoEntityModel> AddAsync(MongoEntityModel entity, CancellationToken cancellationToken = default);
        Task<MongoEntityModel> UpdateAsync(MongoEntityModel entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(MongoEntityModel entity, CancellationToken cancellationToken = default);
    }
}
