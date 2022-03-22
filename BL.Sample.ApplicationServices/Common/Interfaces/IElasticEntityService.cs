using Nest;
using System;
using System.Threading;
using System.Threading.Tasks;
using ElasticEntityModel = BL.Sample.Domain.Entities.ElasticEntity;

namespace BL.Sample.ApplicationServices.Common.Interfaces
{
    public interface IElasticEntityService
    {
        Task<ISearchResponse<ElasticEntityModel>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<ISearchResponse<ElasticEntityModel>> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IndexResponse> AddAsync(ElasticEntityModel entity, CancellationToken cancellationToken = default);
        Task<UpdateResponse<ElasticEntityModel>> UpdateAsync(ElasticEntityModel entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(ElasticEntityModel entity, CancellationToken cancellationToken = default);
    }
}
