using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;
using SmartHouse.Core.Services;
using SmartHouse.Infrastructure.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Services
{
    public class GarbageService : BaseService, IGarbageService
    {
        public GarbageService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : 
            base(unitOfWork, httpContext) { }

        public async Task CreateAsync(Garbage model)
        {
            await unitOfWork.GarbageRepository.AddAsync(model.Create(model, Email));
        }

        public async Task DeleteAsync(string Id)
        {
            var garbage = await unitOfWork.GarbageRepository.GetByIdAsync(Id);
            if (garbage == null)
                throw new NotFoundException("Garbage not found or already removed");
            unitOfWork.GarbageRepository.Remove(garbage.Delete(Email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Garbage>> GetAllAsync()
        {
            return await unitOfWork.GarbageRepository.GetAllAsync();
        }

        public async Task<Garbage> GetAsync(string Id)
        {
            return await unitOfWork.GarbageRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Garbage model)
        {
            var garbage = await unitOfWork.GarbageRepository.GetByIdAsync(model.Id);
            if (garbage == null) {
                throw new NotFoundException("Garbage not found or already removed");
            }
            unitOfWork.GarbageRepository.Update(garbage.Update(model, Email));
            await unitOfWork.CommitAsync();
        }
    }
}
