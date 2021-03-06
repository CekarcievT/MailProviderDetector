﻿using MailProviderDetector;
using System;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp sturtUp = new StartUp();
            var mailProviderDetector = sturtUp.InitClass();
            // user interaction if the program should use own test addresses or the user will enter his
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

                    //test with office 365
                    result = mailProviderDetector.DetectProviderFromEmailAddress("testOutlook@students.finki.ukim.mk");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    // test with google account (has different host after @, but in the background the exchange server is from google 
                    result = mailProviderDetector.DetectProviderFromEmailAddress("testGoogle@itcrowd.me");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    // other imap 
                    result = mailProviderDetector.DetectProviderFromEmailAddress("testOther@inden.si");
                    Console.WriteLine(result.EmailAddress + " - " + result.ProviderName);

                    // bad format mail address case
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
