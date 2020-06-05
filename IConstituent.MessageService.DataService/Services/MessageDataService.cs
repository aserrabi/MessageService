using IConstituent.MessageService.DataStore.Models;
using IConstituent.MessageService.DataStore.Services;
using System.Collections.Generic;

namespace IConstituent.MessageService.DataService
{
    class MessageDataService : IMessageDataService
    {

        private readonly IMessageModelService messageModelService;

        public MessageDataService(IMessageModelService messageModelService)
        {
            this.messageModelService = messageModelService;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return this.messageModelService.GetAllMessages();
        }

        public Message GetMessage(long messageId)
        {
            return this.messageModelService.GetMessage(messageId);
        }

        public Message SendMessage(Message message)
        {
            return this.messageModelService.InsertMessage(message);
        }
    }
}
