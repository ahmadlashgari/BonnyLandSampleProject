using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BL.Sample.Infrastructure.Persistence
{
    public class BLDbContextFactory : IDesignTimeDbContextFactory<BLDbContext>
    {
        public BLDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BLDbContext>();
            //optionsBuilder.UseSqlServer("Host=postgres;Database=bl_sample;Username=postgres;Password=Infusion@9999");
            optionsBuilder.UseNpgsql("Host=postgres;Database=bl_sample;Username=postgres;Password=Infusion@9999")
                .UseSnakeCaseNamingConvention();

            return new BLDbContext(optionsBuilder.Options);
        }
    }
}
