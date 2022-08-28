using SmartHouse.Core.Repository;
using SmartHouse.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartHouseDbContext context;
        private IUserRepository _userRepository;
        private IWaterBillRepository _waterBillRepository;
        private IRentRepository _rentRepository;
        private IGarbageRepository _garbageRepository;
        private IUtilityRepository _utilityRepository;

        public UnitOfWork(SmartHouseDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);
        public IWaterBillRepository WaterBillRepository => _waterBillRepository ??= new WaterBillRepository(context);
        public IRentRepository RentRepository => _rentRepository ??= new RentRepository(context);
        public IGarbageRepository GarbageRepository => _garbageRepository ??= new GarbageRepository(context);

        public IUtilityRepository UtilityRepository => _utilityRepository ??= new UtilityRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
