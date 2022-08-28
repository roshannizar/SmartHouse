using Microsoft.AspNetCore.SignalR;
using SmartHouse.Shared.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.SignalR.Services
{
    public interface INotificationService
    {
        Task SendMessage(string message, string user);
    }

    public class NotificationService : INotificationService
    {
        private readonly IHubContext<MessageHub> hubContext;

        public NotificationService(IHubContext<MessageHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task SendMessage(string message, string user)
        {
            MessageHub messageHub = new MessageHub()
            {
                Message = message
            };

            return hubContext.Clients.All.SendAsync("notification", messageHub);
        }
    }
}
