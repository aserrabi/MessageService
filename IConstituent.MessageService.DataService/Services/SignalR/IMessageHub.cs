using IConstituent.MessageService.DataStore.Models;
using System.Threading.Tasks;

namespace IConstituent.MessageService.DataService.Services.SignalR
{
    interface IMessageHub
    {
        Task SendMessage(Message message);
    }
}
