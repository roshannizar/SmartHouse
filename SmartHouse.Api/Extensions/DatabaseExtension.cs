using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHouse.Infrastructure.DbContexts;

namespace SmartHouse.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabaseExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContextPool<SmartHouseDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SmartHouseDb"));
            });
        }
    }
}
