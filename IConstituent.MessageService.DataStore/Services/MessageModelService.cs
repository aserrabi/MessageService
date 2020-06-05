using IConstituent.MessageService.DataStore.DBContext;
using IConstituent.MessageService.DataStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace IConstituent.MessageService.DataStore.Services
{
    public class MessageModelService : IMessageModelService
    {
        private readonly DbContextFactory dbContextFactory;

        public MessageModelService(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            using (var context = dbContextFactory.GetDbContext())
            {
                context.Database.EnsureCreated();
                return context.Message.ToList();
            }
        }

        public Message GetMessage(long messageId)
        {
            using (var context = dbContextFactory.GetDbContext())
            {
                context.Database.EnsureCreated();
                return context.Message
                    .Where(x => x.Id == messageId)
                    .FirstOrDefault();
            }
        }

        public Message InsertMessage(Message message)
        {
            using (var context = this.dbContextFactory.GetDbContext())
            {
                context.Database.EnsureCreated();
                var entry = context.Message.Add(message);
                context.SaveChanges();
                return entry.Entity;
            }
        }
    }
}
