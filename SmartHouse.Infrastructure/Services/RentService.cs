using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;
using SmartHouse.Core.Services;
using SmartHouse.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Services
{
    public class RentService : BaseService, IRentService
    {

        public RentService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext)
        {
           
        }

        public async Task CreateAsync(Rent model)
        {
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
            return await unitOfWork.RentRepository.GetAllAsync();
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
