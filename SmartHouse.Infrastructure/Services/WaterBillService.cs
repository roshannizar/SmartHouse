using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;
using SmartHouse.Core.Services;
using SmartHouse.Infrastructure.Common;
using SmartHouse.Shared.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Services
{
    public class WaterBillService : BaseService, IWaterBillService
    {

        public WaterBillService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext)
        {
        }

        public async Task CreateAsync(WaterBill model)
        {
            await unitOfWork.WaterBillRepository.AddAsync(model.Create(model));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var bill = await unitOfWork.WaterBillRepository.GetByIdAsync(Id);
            if (bill == null)
                throw new NotFoundException("Water bill not found or already removed");
            unitOfWork.WaterBillRepository.Remove(WaterBill.Delete(email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<WaterBill>> GetAllAsync()
        {
            return await unitOfWork.WaterBillRepository.GetAllAsync();
        }

        public async Task<WaterBill> GetAsync(string Id)
        {
            return await unitOfWork.WaterBillRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(WaterBill model)
        {
            var bill = await unitOfWork.WaterBillRepository.GetByIdAsync(model.Id);

            if (bill == null) {
                throw new NotFoundException("Water bill not found or already removed");
            }

            unitOfWork.WaterBillRepository.Update(model.Update(model));
            await unitOfWork.CommitAsync();
        }
    }
}
