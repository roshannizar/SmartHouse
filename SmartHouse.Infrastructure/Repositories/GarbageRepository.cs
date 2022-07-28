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
    public class GarbageRepository : IRepository<Garbage>, IGarbageRepository
    {
        private readonly SmartHouseDbContext context;
        public GarbageRepository(SmartHouseDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Garbage entity)
        {
            await context.Garbages.AddAsync(entity); 
            context.SaveChanges();
        }
        public IEnumerable<Garbage> Find(Expression<Func<Garbage, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Garbage>> GetAllAsync()
        {
            return await context.Garbages.Include(x => x.User).AsNoTracking().AsQueryable().OrderByDescending(c => c.CreationDate).ToListAsync();
        }
        public async Task<Garbage> GetByIdAsync(string id)
        {
            return await context.Garbages.AsNoTracking().AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
        }
        public void Remove(Garbage entity)
        {
            context.Garbages.Update(entity);
        }
        public async Task<Garbage> SingleOrDefaultAsync(Expression<Func<Garbage, bool>> predicate)
        {
            return await context.Garbages.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }
        public void Update(Garbage entity)
        {
            context.Garbages.Update(entity);
        }
    }
}
