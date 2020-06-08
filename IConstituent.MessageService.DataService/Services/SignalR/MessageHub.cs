using IConstituent.MessageService.DataStore.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IConstituent.MessageService.DataService.Services.SignalR
{
    public class MessageHub : Hub, IMessageHub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("NewMessage", message);
        }
    }
}
