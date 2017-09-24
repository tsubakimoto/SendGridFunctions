using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;

namespace SendGridFunctions
{
    public static class Queue2SendGrid
    {
        [FunctionName("Queue2SendGrid")]
        public static void Run([QueueTrigger("mailbysendgrid", Connection = "QueueStorage")]string address, TraceWriter log, [SendGrid] out Mail message)
        {
            log.Info($"C# Queue trigger function processed: {address}");

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            message = new Mail
            {
                From = new Email("noreply@example.com"),
                Personalization = new List<Personalization>
                {
                    new Personalization
                    {
                        Subject = "Hello from Queue2SendGrid",
                        Tos = new List<Email>
                        {
                            new Email(address)
                        }
                    }
                },
                Contents = new List<Content>
                {
                    new Content("text/plain", $"Lorem ipsum ... {timestamp}")
                }
            };
        }
    }
}
