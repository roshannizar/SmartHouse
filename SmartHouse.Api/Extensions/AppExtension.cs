using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHouse.Core.Repository;
using SmartHouse.Core.Services;
using SmartHouse.Email.Services;
using SmartHouse.Infrastructure.DbContexts;
using SmartHouse.Infrastructure.Repositories;
using SmartHouse.Infrastructure.Services;
using SmartHouse.Queues.Services;
using SmartHouse.Shared.Core.Helpers;
using SmartHouse.SignalR.Services;
using System;

namespace SmartHouse.Api.Extensions
{
    public static class AppExtension
    {
        public static void AddAppExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<DbContext, SmartHouseDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<IWaterBillService, WaterBillService>();
            services.AddTransient<IRentService, RentService>();
            services.AddTransient<IGarbageService, GarbageService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IBackgroundService, BackgroundService>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var emailConfig = Configuration
                .GetSection("SendGrid")
                .Get<EmailSenderOptions>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailService, EmailService>();

            services.AddHealthChecks();
        }

        public static void AddAppMiddleware(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/message");
            });

            app.UseHealthChecks("/health");
        }
    }
}
