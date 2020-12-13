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
            // validating the input parameter (mail address)
            if(!MailValidator.IsValidEmail(emailAddress))
            {
                throw new ApplicationException("Invalid e-mail format");
            }
            DetectedProviderDTO detectedProvider = new DetectedProviderDTO();
            detectedProvider.EmailAddress = emailAddress;

            //get the name of the host from the email address
            var address = emailAddress.Split("@")[1];
            
            // with DnsResolver we search from the Mx records to see what mail exchange server is responsible
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
