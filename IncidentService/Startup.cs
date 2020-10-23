using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentService.Model;
using IncidentService.Persistence;
using IncidentService.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IncidentService
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
            services.AddDbContext<IncidentDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("IncidentServiceAPI", new OpenApiInfo()
                {
                    Title = "Incident Service API",
                    Version = "1.0.0",
                });
            });

            services.AddControllers();

            services.AddScoped<IncidentRepository>();
            services.AddScoped<IncidentStatusRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger(setupAction =>
            {
                setupAction.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint($"/swagger/IncidentServiceAPI/swagger.json", "Incident Service API");
                setupAction.DocExpansion(DocExpansion.List);
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
