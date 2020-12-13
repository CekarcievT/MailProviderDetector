using MailProviderDetector.Models;

namespace MailProviderDetector.Interfaces
{
    public interface IMailProviderDetectorService
    {
        DetectedProviderDTO DetectProviderFromEmailAddress(string emailAddress);
    }
}
