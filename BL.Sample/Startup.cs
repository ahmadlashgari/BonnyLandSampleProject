using BL.Framework.AspNetCore;
using BL.Sample.ApplicationServices;
using BL.Sample.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsPolicy();

            services.AddPostgresDbContext(Configuration.GetConnectionString("DefaultConnection"));
            //services.AddSqlDbContext(Configuration.GetConnectionString("DefaultConnection"));

            // Identity
            services.AddIdentityServerApiAuthentication(Configuration);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorPrivilege", policy =>
                {
                    policy.RequireRole("Administrator");
                });

                options.AddPolicy("ContentProducerPrivilege", policy =>
                {
                    policy.RequireRole("ContentProducer", "Administrator");
                });
            });

            // Swagger
            services.AddSwaggerServices(Configuration);

            // Mvc
            services.AddMvcBase();

            // Health Checks
            services.AddHealthChecksCore().AddPosgtreSqlHealthChecks(Configuration);

            // Core Services
            services.AddApplicationServices(Configuration);
            services.AddInfrastructureServices();
            //services.AddLocaleServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandlers(env);

            // Swagger
            app.UseSwaggerConfiguration(Configuration);

            app.UseAppCore();

            app.UseEndPoints(true, true);
        }
    }
}
