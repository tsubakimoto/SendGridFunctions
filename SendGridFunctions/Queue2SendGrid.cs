using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SendGridFunctions
{
    public static class Queue2SendGrid
    {
        [FunctionName("Queue2SendGrid")]
        public static void Run([QueueTrigger("mailbysendgrid", Connection = "QueueStorage")]string address, TraceWriter log, [SendGrid] out Mail message)
        {
            log.Info($"C# Queue trigger function processed: {address}");

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var config = new SendGridConfig();

            message = new Mail
            {
                From = new Email(config.From),
                Personalization = new List<Personalization>
                {
                    new Personalization
                    {
                        Subject = config.Subject,
                        Tos = new List<Email>
                        {
                            new Email(address)
                        }
                    }
                },
                Contents = new List<Content>
                {
                    new Content("text/plain", string.Format(config.Body, timestamp))
                }
            };
        }
    }

    public class SendGridConfig
    {
        public string From { get; } = ConfigurationManager.AppSettings["SendGridFrom"];
        public string Subject { get; } = ConfigurationManager.AppSettings["SendGridSubject"];
        public string Body { get; } = ConfigurationManager.AppSettings["SendGridBody"];
    }
}
