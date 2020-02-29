using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace instagram
{
    [Authorize]

        public class ChatHub : Hub
        {
            public async Task SendMessage(string message)
            {  
                await this.Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
            }
        }
    

}
