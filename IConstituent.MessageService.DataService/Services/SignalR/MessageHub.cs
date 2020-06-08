using IConstituent.MessageService.DataStore.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IConstituent.MessageService.DataService.Services.SignalR
{
    public class MessageHub : Hub, IMessageHub
    {
        private readonly IHubContext<MessageHub> hubContext;

        public MessageHub(IHubContext<MessageHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task SendMessage(Message message)
        {
            await this.hubContext.Clients.All.SendAsync("NewMessage", message);
        }
    }
}
