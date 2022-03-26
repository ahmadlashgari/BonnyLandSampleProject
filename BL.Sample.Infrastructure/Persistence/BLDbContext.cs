﻿using BL.Framework.Persistence.EntityFrameworkCore;
using BL.Sample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Sample.Infrastructure.Persistence
{
    public class BLDbContext : DbContext
    {
        private readonly ILogger<BLDbContext> _logger;

        public BLDbContext(DbContextOptions<BLDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public BLDbContext(DbContextOptions<BLDbContext> options, ILogger<BLDbContext> logger) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DbSet<Entity> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            SeedData(builder);
        }

        public override int SaveChanges()
        {
            try
            {
                UpdateEntities();

                var result = base.SaveChanges();

                _logger.LogInformation($"Save Changes result: {result}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Save Changes Error: {ex.Message}", ex);

                return -1;
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            try
            {
                UpdateEntities();

                var result = base.SaveChanges(acceptAllChangesOnSuccess);

                _logger.LogInformation($"Save Changes result: {result}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Save Changes Error: {ex.Message}", ex);

                return -1;
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                UpdateEntities();

                var result = await base.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Save Changes Async result: {result}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException != null ? ex.InnerException.Message : ex.Message, ex);

                return -1;
            }
        }

        public int SaveChangesTransactional()
        {
            using var transaction = Database.BeginTransaction();

            try
            {
                UpdateEntities();

                var result = SaveChanges();
                transaction.Commit();

                _logger.LogInformation($"Save Changes Transactional result: {result}");

                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                _logger.LogError(ex.Message, ex); return -1;
            }
        }

        public async Task<int> SaveChangesTransactionalAsync()
        {
            await using var transaction = await Database.BeginTransactionAsync();

            try
            {
                UpdateEntities();

                var result = await SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation($"Save Changes Transactional Async result: {result}");

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                _logger.LogError(ex.InnerException != null ? ex.InnerException.Message : ex.Message, ex);

                return -1;
            }
        }

        private void UpdateEntities()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is EntityCoreBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityCoreBase)entityEntry.Entity).CreatedOn = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    if (((EntityCoreBase)entityEntry.Entity).IsDeleted)
                    {
                        ((EntityCoreBase)entityEntry.Entity).DeletedOn = DateTime.Now;
                    }
                    else
                    {
                        ((EntityCoreBase)entityEntry.Entity).LastUpdatedOn = DateTime.Now;
                    }
                }
            }
        }

        private ModelBuilder SeedData(ModelBuilder builder)
        {
            //builder.Entity<TEntity>().HasData(new Entity { Id = 1, CreatedOn = DateTime.Now }); 

            return builder;
        }
    }
}
