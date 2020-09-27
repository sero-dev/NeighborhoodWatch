using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeighborhoodWatch.DAC;
using NeighborhoodWatch.DAC.Context;
using NeighborhoodWatch.DAC.Interface;
using Npgsql;
using System;

namespace Neighborhood.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IIncidentRepository, IncidentRepository>();


            var connectionString = new NpgsqlConnectionStringBuilder()
            {
                SslMode = SslMode.Disable,
                Host = Environment.GetEnvironmentVariable("DB_HOST"),
                Username = Environment.GetEnvironmentVariable("DB_USER"),
                Password = Environment.GetEnvironmentVariable("DB_PASS"),
                Database = Environment.GetEnvironmentVariable("DB_NAME"),
                Pooling = true
            };

            services.AddDbContext<IncidentContext>(options =>
                options.UseNpgsql(connectionString.ConnectionString));
            
            services.AddControllers();

            services.AddCors(options =>
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
