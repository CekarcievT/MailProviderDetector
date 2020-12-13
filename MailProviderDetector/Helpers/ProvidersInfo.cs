using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MailProviderDetector.Helpers
{
    public static class ProvidersInfo
    {
        private static readonly Dictionary<string, string> DomainProviders = new Dictionary<string, string> {
            {"outlook.com",                 "Office 365"},
            // not sure about those, for now i didnt find that ms exchange server has anything unique in the mx records different than other imap
            //{"exchangelabs.com",            "Microsoft Exchange"},
            //{"microsoft.com",               "Microsoft Exchange"},
            //{"exchange.ms",                 "Microsoft Exchange"},
            {"google.com",                  "Google"},
            {"googlemail.com",              "Google"}
        };

        public static string GetProviderNameByExchangeName(List<string> exchangeDomainNames)
        {
            string result = "";

            foreach(var domainProvider in DomainProviders)
            {
                var provider = exchangeDomainNames.Where(x => x.Contains(domainProvider.Key)).FirstOrDefault();
                if (provider != null)
                {
                    result = domainProvider.Value;
                    break;
                }
            }

            if (String.IsNullOrEmpty(result))
            {
                result = "Other IMAP";
            }

            return result;
        }
    }
}
