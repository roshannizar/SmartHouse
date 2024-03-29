using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartHouse.Api.Extensions;

namespace SmartHouse.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCoreExtension();
            services.AddSecurityExtension(Configuration);
            services.AddDatabaseExtension(Configuration);
            services.AddSwaggerExtension();
            services.AddAppExtension(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.AddCoreMiddleware();
            app.AddSecurityMiddleware();
            app.AddAppMiddleware();
            app.AddSwaggerMiddleware();
        }
    }
}
