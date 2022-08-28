using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Core.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IWaterBillRepository WaterBillRepository { get; }
        IRentRepository RentRepository { get; }
        IGarbageRepository GarbageRepository { get; }
        IUtilityRepository UtilityRepository { get; }
        Task<int> CommitAsync();
    }
}
