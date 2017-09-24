# SendGridFunctions
## On local development
Prepare `local.settings.json`, example below.  
Also, you can use [Azure storage emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator).

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "QueueStorage",
        "AzureWebJobsDashboard": "",
        "AzureWebJobsSendGridApiKey": "your SendGrid api key",
        "SendGridFrom": "your email from address",
        "SendGridSubject": "your email subject",
        "SendGridBody": "your email body (must contain parameter '{0}')"
    },
    "ConnectionStrings": {
        "QueueStorage": "UseDevelopmentStorage=true"
    }
}
```

## On App Service
Register environment variables to Application Settings on Azure App Services.

* `AzureWebJobsSendGridApiKey`
* `SendGridFrom`
* `SendGridSubject`
* `SendGridBody`
