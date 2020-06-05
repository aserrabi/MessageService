using IConstituent.MessageService.DataStore.Models;
using Microsoft.EntityFrameworkCore;

namespace IConstituent.MessageService.DataStore
{
    public class MessageDbContext : DbContext
    {
        public virtual DbSet<Message> Message { get; set; }

        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.BuildAccount(modelBuilder);
        }

        private void BuildAccount(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Subject).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Author).IsRequired();
                entity.Property(e => e.SentAt).IsRequired();
            });
        }
    }
}
