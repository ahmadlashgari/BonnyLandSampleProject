using BL.Sample.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BL.Sample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = BL.Framework.AspNetCore.HostBuilder.CreateHostBuilder<Startup>(args, true, true).Build();

            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<BLDbContext>();
            await dbContext.Database.MigrateAsync();

            await app.RunAsync();
        }
    }
}
