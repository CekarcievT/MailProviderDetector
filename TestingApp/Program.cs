using MailProviderDetector;
using System;
using System.Threading;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp sturtUp = new StartUp();
            var mailProviderDetector = sturtUp.InitClass();

            Console.WriteLine("Do you want to use your own e-mail address?(Y/N)");
            var key = Console.ReadKey();
            Console.WriteLine("");

            if(key.Key.ToString().ToLower() == "y")
            {
                var address = Console.ReadLine();
                try
                {
                    var result = mailProviderDetector.DetectProviderFromEmailAddress(address);
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                try
                {
                    //test with exchange server
                    var result = mailProviderDetector.DetectProviderFromEmailAddress("testMSExchange@borzen.si");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    result = mailProviderDetector.DetectProviderFromEmailAddress("testOutlook@students.finki.ukim.mk");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    result = mailProviderDetector.DetectProviderFromEmailAddress("testGoogle@itcrowd.me");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    result = mailProviderDetector.DetectProviderFromEmailAddress("testOther@inden.si");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    result = mailProviderDetector.DetectProviderFromEmailAddress("testBadFormat1@in@den.si");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
