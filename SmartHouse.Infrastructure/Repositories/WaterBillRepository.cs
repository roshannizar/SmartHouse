using Microsoft.EntityFrameworkCore;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;
using SmartHouse.Infrastructure.DbContexts;
using SmartHouse.Shared.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Repositories
{
    public class WaterBillRepository : IRepository<WaterBill>, IWaterBillRepository
    {
        private SmartHouseDbContext context;

        public WaterBillRepository(SmartHouseDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(WaterBill entity)
        {
            await context.WaterBills.AddAsync(entity);
        }

        public IEnumerable<WaterBill> Find(Expression<Func<WaterBill, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WaterBill>> GetAllAsync()
        {
            return await context.WaterBills.Include(x => x.User).AsNoTracking().AsQueryable().OrderByDescending(c => c.BillDate).ToListAsync();
        }

        public async Task<WaterBill> GetByIdAsync(string id)
        {
            return await context.WaterBills.AsNoTracking().AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(WaterBill entity)
        {
            context.WaterBills.Update(entity);
        }

        public async Task<WaterBill> SingleOrDefaultAsync(Expression<Func<WaterBill, bool>> predicate)
        {
            return await context.WaterBills.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(WaterBill entity)
        {
            context.WaterBills.Update(entity);
        }
    }
}
