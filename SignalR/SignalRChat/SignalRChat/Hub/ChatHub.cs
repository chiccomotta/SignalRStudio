using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace SignalRChat.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public ChatHub(IConfiguration configuration)
        {
            var t = configuration;
        }

        public async Task AddAction(string user, string action)
        {
            var id = Context.ConnectionId;

            //await Clients.All.SendAsync("ReceiveMessage", user, id);
            await Clients.All.SendAsync("NotifyActionAdded", user, action);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public override Task OnConnectedAsync()
        {
            var user = Context.GetHttpContext().Request.Query["user"].ToString();
            return base.OnConnectedAsync();
        }
    }
}
