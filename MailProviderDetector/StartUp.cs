using Autofac;
using MailProviderDetector.Interfaces;
using MailProviderDetector.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailProviderDetector
{
    public class StartUp
    {
        public IMailProviderDetectorService InitClass() {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MailProviderDetectorService>().As<IMailProviderDetectorService>().SingleInstance();

            var container = builder.Build();
            var mailProviderDetector = container.Resolve<IMailProviderDetectorService>();

            return mailProviderDetector;
        }

    }
}
