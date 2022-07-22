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

        Task<int> CommitAsync();
    }
}
