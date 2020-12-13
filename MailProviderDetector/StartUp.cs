using Autofac;
using MailProviderDetector.Interfaces;
using MailProviderDetector.Services;

namespace MailProviderDetector
{
    public class StartUp
    {
        public IMailProviderDetectorService InitClass() {
            // using container from autofac to create an instance form the created service
            ContainerBuilder builder = new ContainerBuilder();

            // new instance for every call
            builder.RegisterType<MailProviderDetectorService>().As<IMailProviderDetectorService>().SingleInstance();

            var container = builder.Build();
            var mailProviderDetector = container.Resolve<IMailProviderDetectorService>();

            return mailProviderDetector;
        }

    }
}
