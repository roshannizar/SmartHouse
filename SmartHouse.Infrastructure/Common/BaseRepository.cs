using SmartHouse.Infrastructure.DbContexts;

namespace SmartHouse.Infrastructure.Common
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        public readonly SmartHouseDbContext context;

        public BaseRepository(SmartHouseDbContext context)
        {
            this.context = context;
        }
    }
}
