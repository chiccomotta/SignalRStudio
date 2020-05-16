using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

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
            await Clients.Others.SendAsync("NotifyActionAdded", user, action);
        }

        public async Task BrodcastAction(string action)
        {
            await Clients.All.SendAsync("NotifyActionAdded", "ALL USERS", action);
        }

        public override Task OnConnectedAsync()
        {
            // Aggiungo il connectionId al gruppo il cui nome è user
            var user = Context.GetHttpContext().Request.Query["user"].ToString();
            Groups.AddToGroupAsync(Context.ConnectionId, user);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
