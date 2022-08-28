using Hangfire;
using SmartHouse.SignalR.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Queues.Services
{
    public class BackgroundService : IBackgroundService
    {
        private readonly INotificationService notificationService;

        public BackgroundService(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void ExecuteRent(string user)
        {
            BackgroundJob.Schedule(() => SendNotificationAsync(user), TimeSpan.FromSeconds(10));
        }

        #region SendMessage 
        public Task SendNotificationAsync(string user)
        {
            return notificationService.SendMessage("You will be notified for your next rental!" ,user);
        }
        #endregion
    }
}
