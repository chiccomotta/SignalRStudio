using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hub;

namespace SignalRChat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHubContext<ChatHub> hubContext;
        public IndexModel(IHubContext<ChatHub> _hubContext)
        {
            hubContext = _hubContext;
        }

        public void OnGet()
        {
            // Invoke method on client

            var connId = hubContext.Clients.All.SendAsync("SendMessage", "pippo", "Hello");
        }
    }
}
