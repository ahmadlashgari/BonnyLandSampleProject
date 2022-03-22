using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Nest;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.Infrastructure.Services
{
    public class ElasticEntityService : IElasticEntityService
    {
        private readonly ElasticClient _elasticClient;

        public ElasticEntityService(ElasticClient elasticClient, IConfiguration configuration)
        {
            _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
        }

        public async Task<ISearchResponse<ElasticEntity>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _elasticClient.SearchAsync<ElasticEntity>(e => e.Query(q => q.MatchAll()));

            return result;
        }

        public async Task<ISearchResponse<ElasticEntity>> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _elasticClient.SearchAsync<ElasticEntity>(e => e.Query(q => q.Ids(i => i.Values(id))));

            return result;
        }

        public async Task<IndexResponse> AddAsync(ElasticEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _elasticClient.IndexAsync(entity, i => i.Id(entity.Id));

            await _elasticClient.Indices.RefreshAsync();

            return result;
        }

        public async Task<UpdateResponse<ElasticEntity>> UpdateAsync(ElasticEntity entity, CancellationToken cancellationToken = default)
        {
            var request = new UpdateRequest<ElasticEntity, object>(entity);

            var result = await _elasticClient.UpdateAsync<ElasticEntity, object>(entity, e => e.Doc(entity));

            await _elasticClient.Indices.RefreshAsync();

            Debug.WriteLine("--------------------------------------");
            Debug.Write(JsonConvert.SerializeObject(result));
            Debug.WriteLine("--------------------------------------");

            return result;
        }

        public async Task DeleteAsync(ElasticEntity entity, CancellationToken cancellationToken = default)
        {
            await _elasticClient.DeleteAsync<ElasticEntity>(entity);

            await _elasticClient.Indices.RefreshAsync();
        }
    }
}
