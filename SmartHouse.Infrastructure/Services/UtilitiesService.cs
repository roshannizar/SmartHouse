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
    public class UtilitiesService : BaseService, IUtilitiesService
    {

        public UtilitiesService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext)
        {
        }

        public async Task CreateAsync(Utility model)
        {
            await unitOfWork.UtilityRepository.AddAsync(model.Create(model, Email));
        }

        public async Task DeleteAsync(string Id)
        {
            var utility = await unitOfWork.UtilityRepository.GetByIdAsync(Id);
            if (utility == null)
                throw new NotFoundException("Utility not found or already removed");
            unitOfWork.UtilityRepository.Remove(utility.Delete(Email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Utility>> GetAllAsync()
        {
            return await unitOfWork.UtilityRepository.GetAllAsync();
        }

        public async Task<Utility> GetAsync(string Id)
        {
            return await unitOfWork.UtilityRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Utility model)
        {
            var utility = await unitOfWork.UtilityRepository.GetByIdAsync(model.Id);
            if (utility == null)
            {
                throw new NotFoundException("Utility not found or already removed");
            }
            unitOfWork.UtilityRepository.Update(utility.Update(model, Email));
            await unitOfWork.CommitAsync();
        }
    }
}
