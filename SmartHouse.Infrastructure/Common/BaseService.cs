using Microsoft.AspNetCore.Http;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;

namespace SmartHouse.Infrastructure.Common
{
    public class BaseService
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IHttpContextAccessor httpContext;
        public string Email { get; set; }

        public BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext)
        {
            this.unitOfWork = unitOfWork;
            this.httpContext = httpContext;
            LoadUser();
        }

        private void LoadUser()
        {
            var user = (User)httpContext.HttpContext.Items["User"];
            Email = user?.Id;
        }
    }
}
