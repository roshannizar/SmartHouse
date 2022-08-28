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
    public class UtilityRepository : IRepository<Utility>,IUtilityRepository
    {
        private readonly SmartHouseDbContext context;

        public UtilityRepository(SmartHouseDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Utility entity)
        {
            await context.Utilities.AddAsync(entity);
        }

        public async Task<IEnumerable<Utility>> GetAllAsync()
        {
            return await context.Utilities.Include(x => x.User).AsNoTracking().AsQueryable().OrderByDescending(c => c.CreationDate).ToListAsync();
        }

        public IEnumerable<Utility> Find(Expression<Func<Utility, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Utility> GetByIdAsync(string id)
        {
            return await context.Utilities.AsNoTracking().AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Utility entity)
        {
            context.Utilities.Update(entity);
        }

        public async Task<Utility> SingleOrDefaultAsync(Expression<Func<Utility, bool>> predicate)
        {
            return await context.Utilities.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(Utility entity)
        {
            context.Utilities.Update(entity);
        }
    }
}
