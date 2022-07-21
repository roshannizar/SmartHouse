using SmartHouse.Core.Repository;
using SmartHouse.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartHouseDbContext context;
        private IUserRepository _userRepository;

        public UnitOfWork(SmartHouseDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
