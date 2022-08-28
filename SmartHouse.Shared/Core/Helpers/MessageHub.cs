using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Shared.Core.Helpers
{
    public class MessageHub : Hub
    {
        public string Message { get; set; }
    }
}
