#r "SendGrid"
using System;
using SendGrid.Helpers.Mail;

public static void Run(string myQueueItem, TraceWriter log, out Mail message)
{
    log.Info($"C# Queue trigger function processed: {myQueueItem}");

    message = new Mail
    {
        Subject = "Hello from yutasendgridfunction"
    };

    var personalization = new Personalization();
    personalization.AddTo(new Email(myQueueItem));

    Content content = new Content
    {
        Type = "text/plain",
        Value = "Lorem ipsum ... " + DateTime.Now.ToString("yyyyMMddHHmmss")
    };
    message.AddContent(content);
    message.AddPersonalization(personalization);
}
