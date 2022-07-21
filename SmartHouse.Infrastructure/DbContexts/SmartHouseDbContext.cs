using Microsoft.EntityFrameworkCore;
using SmartHouse.Core.Models;
using SmartHouse.Shared.Core.Enums;

namespace SmartHouse.Infrastructure.DbContexts
{
    public class SmartHouseDbContext : DbContext
    {
        public SmartHouseDbContext(DbContextOptions<SmartHouseDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasQueryFilter(u => u.RecordState == RecordState.Active);
        }
    }
}
