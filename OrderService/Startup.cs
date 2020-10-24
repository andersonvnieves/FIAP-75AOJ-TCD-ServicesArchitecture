using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OrderService.Persistence;
using OrderService.Persistence.Repositories;
using OrderService.Queue;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OrderService
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
            services.AddDbContextPool<OrderDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("OrderServiceAPI", new OpenApiInfo()
                {
                    Title = "Order Service API",
                    Version = "1.0.0",
                });
            });

            services.AddControllers();
            services.AddSingleton<OrderItemsRepository>();
            services.AddSingleton<OrderRepository>();
            services.AddSingleton<OrderStatusRepository>();
            services.AddSingleton<ShippingAddressRepository>();

            services.AddSingleton<ITopicClient>(x => new TopicClient(Configuration.GetValue<string>("ServiceBus:ConnectionString"),
                Configuration.GetValue<string>("ServiceBus:TopicName")));
            services.AddSingleton<OrderMessagePublisher>();

            services.AddSingleton<ISubscriptionClient>(x =>
                new SubscriptionClient(Configuration.GetValue<string>("ServiceBus:TopicName"),
                    Configuration.GetValue<string>("ServiceBus:TopicName"),
                    Configuration.GetValue<string>("ServiceBus:SubscriptionName")));
            services.AddHostedService<OrderConsumerService>();

            

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
                setupAction.SwaggerEndpoint($"/swagger/OrderServiceAPI/swagger.json", "Order Service API");
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
