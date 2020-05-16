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
        }

        public async void OnPostAddNewAction(string action)
        {
            // ...add action in db and notify all clients
            await hubContext.Clients.All.SendAsync("NotifyActionAdded", "chicco", "call hospital");
        }
    }
}
