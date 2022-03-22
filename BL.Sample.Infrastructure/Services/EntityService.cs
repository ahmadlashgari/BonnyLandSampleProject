using Ardalis.Specification;
using BL.Framework.Persistence.EntityFrameworkCore.Interfaces;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.Infrastructure.Services
{
    public class EntityService : IEntityService
    {
        private readonly IReadRepository<Entity> _readRepository;
        private readonly IRepository<Entity> _repository;

        public EntityService(IReadRepository<Entity> readRepository, IRepository<Entity> repository)
        {
            _readRepository = readRepository;
            _repository = repository;
        }

        public async Task<List<Entity>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await _readRepository.ListAsync(cancellationToken);
        }

        public async Task<List<Entity>> FindAllBySpecAsync(ISpecification<Entity> spec, CancellationToken cancellationToken = default)
        {
            return await _readRepository.ListAsync(spec, cancellationToken);
        }

        public async Task<Entity> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _readRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<Entity> FindBySpecAsync(ISingleResultSpecification<Entity> spec, CancellationToken cancellationToken = default)
        {
            return await _readRepository.GetBySpecAsync(spec, cancellationToken);
        }

        public async Task<Entity> AddAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            return await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<Entity> UpdateAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(entity, cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}
