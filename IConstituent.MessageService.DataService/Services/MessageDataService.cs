using IConstituent.MessageService.DataService.Services.SignalR;
using IConstituent.MessageService.DataStore.Models;
using IConstituent.MessageService.DataStore.Services;
using System.Collections.Generic;

namespace IConstituent.MessageService.DataService
{
    class MessageDataService : IMessageDataService
    {

        private readonly IMessageModelService messageModelService;
        private readonly IMessageHub messageHub;

        public MessageDataService(IMessageModelService messageModelService, IMessageHub messageHub)
        {
            this.messageModelService = messageModelService;
            this.messageHub= messageHub;
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
            var newMessage = this.messageModelService.InsertMessage(message);

            if (newMessage != null)
            {
                this.messageHub.SendMessage(message);
            }

            return newMessage;

        }
    }
}
