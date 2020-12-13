using System;
using System.Collections.Generic;
using System.Text;

namespace MailProviderDetector.Models
{
    public class DetectedProviderDTO
    {
        public string EmailAddress { get; set; }
        public string ProviderName { get; set; }
    }
}
