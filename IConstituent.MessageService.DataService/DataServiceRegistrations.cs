using Autofac;
using IConstituent.MessageService.DataService.Services.SignalR;
using Microsoft.Extensions.Configuration;

namespace IConstituent.MessageService.DataService
{
    public class DataServiceRegistrations : Module
    {
        private readonly IConfiguration configuration;

        public DataServiceRegistrations(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            this.InstallServices(builder);
        }

        private void InstallServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MessageHub>().As<IMessageHub>().SingleInstance();
            containerBuilder.RegisterType<MessageDataService>().As<IMessageDataService>().SingleInstance();
        }
    }
}
