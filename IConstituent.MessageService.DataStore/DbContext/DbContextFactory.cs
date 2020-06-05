using Microsoft.EntityFrameworkCore;

namespace IConstituent.MessageService.DataStore.DBContext
{
    public class DbContextFactory
    {
        private readonly DbContextOptions<MessageDbContext> dbContextOptions;

        internal DbContextFactory(DbContextOptions<MessageDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public MessageDbContext GetDbContext()
        {
            return new MessageDbContext(this.dbContextOptions);
        }
    }
}
