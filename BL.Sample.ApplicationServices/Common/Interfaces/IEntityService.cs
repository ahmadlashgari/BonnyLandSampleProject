using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EntityModel = BL.Sample.Domain.Entities.Entity;

namespace BL.Sample.ApplicationServices.Common.Interfaces
{
    public interface IEntityService
    {
        Task<List<EntityModel>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<List<EntityModel>> FindAllBySpecAsync(ISpecification<EntityModel> spec, CancellationToken cancellationToken = default);
        Task<EntityModel> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<EntityModel> FindBySpecAsync(ISingleResultSpecification<EntityModel> spec, CancellationToken cancellationToken = default);
        Task<EntityModel> AddAsync(EntityModel entity, CancellationToken cancellationToken = default);
        Task<EntityModel> UpdateAsync(EntityModel entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(EntityModel entity, CancellationToken cancellationToken = default);
    }
}