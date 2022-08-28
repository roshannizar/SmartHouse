using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;
using SmartHouse.Core.Services;
using SmartHouse.Infrastructure.Common;
using SmartHouse.Queues.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Services
{
    public class RentService : BaseService, IRentService
    {
        private readonly IBackgroundService backgroundService;

        public RentService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext, IBackgroundService backgroundService) 
            : base(unitOfWork, httpContext)
        {
            this.backgroundService = backgroundService;
        }

        public async Task CreateAsync(Rent model)
        {
            var date = DateTime.Now;

            var query = await unitOfWork.RentRepository.GetAllAsync();

            query = query.OrderByDescending(o => o.PaidDate)
                .Where(o => o.PaidDate.Year == date.Year && o.PaidDate.Month == date.Month)
                .Where(o => o.UserId == Email)
                .ToList();

            if(query.Count() <= 0)
            {
                backgroundService.ExecuteRent(Email);
            }
            await unitOfWork.RentRepository.AddAsync(model.Create(model, Email));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var rent = await unitOfWork.RentRepository.GetByIdAsync(Id);
            if (rent == null)
                throw new NotFoundException("Water bill not found or already removed");
            unitOfWork.RentRepository.Remove(rent.Delete(Email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            var query = await unitOfWork.RentRepository.GetAllAsync();
            if (Role == Shared.Core.Enums.Role.Admin)
                return query;
            else
                return query.Where(g => g.UserId == Email).ToList();
        }

        public async Task<Rent> GetAsync(string Id)
        {
            return await unitOfWork.RentRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Rent model)
        {
            var rent = await unitOfWork.RentRepository.GetByIdAsync(model.Id);

            if (rent == null)
            {
                throw new NotFoundException("Water bill not found or already removed");
            }

            unitOfWork.RentRepository.Update(rent.Update(model, Email));
            await unitOfWork.CommitAsync();
        }
    }
}
