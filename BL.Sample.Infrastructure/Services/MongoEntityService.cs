using BL.Framework.Persistence.MongoDB.Interfaces;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.Infrastructure.Services
{
    public class MongoEntityService : IMongoEntityService
    {
        private readonly IReadRepository<MongoEntity> _readRepository;
        private readonly IRepository<MongoEntity> _repository;

        public MongoEntityService(IMongoClient mongoClient, IConfiguration configuration, IReadRepository<MongoEntity> readRepository, IRepository<MongoEntity> repository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            var mongoDbConfiguration = configuration.GetSection("MongoDB");
            var mongoDbDatabaseConfiguration = mongoDbConfiguration.GetSection("BookDatabase");

            var mongoDatabase = mongoClient.GetDatabase(mongoDbDatabaseConfiguration.GetValue<string>("DatabaseName"));

            _readRepository.Collection = mongoDatabase.GetCollection<MongoEntity>(mongoDbDatabaseConfiguration.GetValue<string>("CollectionName"));
            _repository.Collection = mongoDatabase.GetCollection<MongoEntity>(mongoDbDatabaseConfiguration.GetValue<string>("CollectionName"));
        }

        public async Task<List<MongoEntity>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _readRepository.GetAllAsync();

            return result;
        }

        public async Task<MongoEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _readRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<MongoEntity> AddAsync(MongoEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.InsertOneAsync(entity);

            return entity;
        }

        public Task<MongoEntity> UpdateAsync(MongoEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(MongoEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
