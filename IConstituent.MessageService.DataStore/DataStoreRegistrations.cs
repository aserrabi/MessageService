using Autofac;
using IConstituent.MessageService.DataStore.DBContext;
using IConstituent.MessageService.DataStore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IConstituent.MessageService.DataStore
{
    public class DataStoreRegistrations : Module
    {
        private readonly IConfiguration configuration;
        private readonly IServiceCollection services;

        public DataStoreRegistrations(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            this.InstallDb(builder);
            this.InstallServices(builder);
            
        }

        private void InstallDb(ContainerBuilder builder)
        {
            var dbContextOptions = new DbContextOptionsBuilder<MessageDbContext>()
                .UseMySQL(this.configuration["ConnectionString"])
                .Options;

            var dbContextFactory = new DbContextFactory(dbContextOptions);
            builder.RegisterInstance(dbContextFactory);
        }

        private void InstallServices(ContainerBuilder builder) 
        {
            builder.RegisterType<MessageModelService>().As<IMessageModelService>().SingleInstance();
            
        }
    }
}
