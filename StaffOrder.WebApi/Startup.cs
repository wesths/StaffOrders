using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using StaffOrder.Domain.Contracts;
using StaffOrder.Infrastructure.Configurations;
using StaffOrder.Infrastructure.Configurations.ConfigModels;
using StaffOrder.Infrastructure.Configurations.Contracts;
using StaffOrder.Infrastructure.Connection;
using StaffOrder.Infrastructure.Logging;
using StaffOrder.Infrastructure.Repositories.ATB;
using StaffOrder.Infrastructure.Repositories.StaffOrder;
using StaffOrder.Infrastructure.Repositories.Stock;
using StaffOrder.Infrastructure.Tracking;
using StaffOrder.Interface.Contracts;
using StaffOrder.Service;
using StaffOrder.WebApi.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace StaffOrder
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            LogManager.Configuration = new XmlLoggingConfiguration($"nlog.config");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add SwaggerUI to the API
            var pathToDoc = Configuration["Swagger:FileName"];
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Pre Agreement Quotation Resource Service", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName); //prevents identical schemaids error on swagger
            });

            // Add our Config object(s) so it can be injected [Dependency Injection]
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<ConfigSettings>(Configuration.GetSection("ConfigSettings"));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<ServicesEndpoints>(Configuration.GetSection("ServicesEndpoints"));

            // Dependency injection - Config Models
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<AppSettings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConfigSettings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConnectionStrings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ServicesEndpoints>>().Value);            

            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton(Configuration); // IConfigurationRoot

            // Dependency injection - pass on X-Tracking-Id so subsequent http calls can be grouped together in logging
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Dependency injection - Internal Services
            services.AddTransient<IConfigService, ConfigService>();

            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IAgentService, AgentService>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IATBRepo, ATBRepo>();
            services.AddTransient<IStaffOrderRepo, StaffOrderRepo>();
            services.AddTransient<IStockRepo, StockRepo>();
            services.AddTransient<IManagementRepo, ManagementRepo>();

            // Dependency injection - Logging
            services.AddTransient<ILoggerService, LoggerService>();

            // Tracking management - Tracking
            services.AddTransient<ITrackingService, TrackingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();

            app.UseStaticFiles();
            app.UseExceptionHandleMiddleware();


            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
