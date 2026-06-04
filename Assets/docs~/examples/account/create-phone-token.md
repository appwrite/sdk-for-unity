```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

Token result = await account.CreatePhoneToken(
    userId: "<USER_ID>",
    phone: "+12065550100"
);
```
