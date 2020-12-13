using ARSoft.Tools.Net.Dns;
using MailProviderDetector.Helpers;
using MailProviderDetector.Interfaces;
using MailProviderDetector.Models;
using System;
using System.Collections.Generic;

namespace MailProviderDetector.Services
{
    public class MailProviderDetectorService : IMailProviderDetectorService
    {
        public MailProviderDetectorService() { }
        public DetectedProviderDTO DetectProviderFromEmailAddress(string emailAddress)
        {
            if(!MailValidator.IsValidEmail(emailAddress))
            {
                throw new ApplicationException("Invalid e-mail format");
            }
            DetectedProviderDTO detectedProvider = new DetectedProviderDTO();
            detectedProvider.EmailAddress = emailAddress;

            var address = emailAddress.Split("@")[1];

            var resolver = new DnsStubResolver();
            var records = resolver.Resolve<MxRecord>(address, RecordType.Mx);

            List<string> exchangeDomainServersResult = new List<string>();
            foreach (var record in records)
            {
                exchangeDomainServersResult.Add(record.ExchangeDomainName?.ToString());
            }

            var providerName = ProvidersInfo.GetProviderNameByExchangeName(exchangeDomainServersResult);
            detectedProvider.ProviderName = providerName;

            return detectedProvider;
        }
    }
}
