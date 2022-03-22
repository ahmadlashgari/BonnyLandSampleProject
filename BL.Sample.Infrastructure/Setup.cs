using BL.Framework;
using BL.Framework.Persistence.EntityFrameworkCore;
using BL.Framework.Persistence.EntityFrameworkCore.Interfaces;
using BL.Sample.ApplicationServices.Common.Interfaces;
using BL.Sample.Infrastructure.Persistence;
using BL.Sample.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BL.Sample.Infrastructure
{
    public static class Setup
    {
        public static void AddPostgresDbContext(this IServiceCollection services, string connectionString) =>
            services.AddPostgreSqlDbContext<BLDbContext>(connectionString,
                typeof(Setup).GetTypeInfo().Assembly.GetName().Name);

        public static void AddSqlDbContext(this IServiceCollection services, string connectionString) =>
            services.AddSqlServerDbContext<BLDbContext>(connectionString,
                typeof(Setup).GetTypeInfo().Assembly.GetName().Name);

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddInfrastructureServicesCore();

            services.AddTransient(typeof(IRepository<>), typeof(EFRepositoryBase<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(EFReadRepositoryBase<>));
            services.AddTransient(typeof(Framework.Persistence.MongoDB.Interfaces.IRepository<>), typeof(MongoRepositoryBase<>));
            services.AddTransient(typeof(Framework.Persistence.MongoDB.Interfaces.IReadRepository<>), typeof(MongoReadRepositoryBase<>));

            services.AddTransient<IEntityService, EntityService>();
            services.AddTransient<IMongoEntityService, MongoEntityService>();
            services.AddTransient<IElasticEntityService, ElasticEntityService>();

            return services;
        }
    }
}
