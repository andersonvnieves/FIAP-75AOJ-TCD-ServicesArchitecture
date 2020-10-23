using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using ProductService.Persistence;
using ProductService.Persistence.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ProductService
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
            services.AddDbContext<ProductDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("ProductServiceAPI", new OpenApiInfo()
                {
                    Title = "Product Service API",
                    Version = "1.0.0",
                });
            });

            services.AddControllers();

            services.AddScoped<CategoryRepository>();
            services.AddScoped<KeyWordRepository>();
            services.AddScoped<ProductRepository>();
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
                setupAction.SwaggerEndpoint($"/swagger/ProductServiceAPI/swagger.json", "Product Service API");
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
