using IConstituent.MessageService.DataStore.Models;
using System.Collections.Generic;

namespace IConstituent.MessageService.DataService
{
    public interface IMessageDataService
    {
        Message SendMessage(Message message);
        IEnumerable<Message> GetAllMessages();
        Message GetMessage(long messageId);
    }
}
