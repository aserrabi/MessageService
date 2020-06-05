using IConstituent.MessageService.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConstituent.MessageService.DataStore.Services
{
    public interface IMessageModelService
    {
        Message InsertMessage(Message message);
        IEnumerable<Message> GetAllMessages();
        Message GetMessage(long messageId);
    }
}
