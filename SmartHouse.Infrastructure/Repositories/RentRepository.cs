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
    public class RentRepository : IRepository<Rent>, IRentRepository
    {
        private readonly SmartHouseDbContext context;

        public RentRepository(SmartHouseDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Rent entity)
        {
            await context.Rents.AddAsync(entity);
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await context.Rents.Include(x => x.User).AsNoTracking().AsQueryable().OrderByDescending(c => c.CreationDate).ToListAsync();
        }

        public IEnumerable<Rent> Find(Expression<Func<Rent, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Rent> GetByIdAsync(string id)
        {
            return await context.Rents.AsNoTracking().AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Rent entity)
        {
            context.Rents.Update(entity);
        }

        public async Task<Rent> SingleOrDefaultAsync(Expression<Func<Rent, bool>> predicate)
        {
            return await context.Rents.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(Rent entity)
        {
            context.Rents.Update(entity);
        }
    }
}
