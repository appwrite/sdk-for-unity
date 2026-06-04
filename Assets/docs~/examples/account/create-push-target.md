```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

Target result = await account.CreatePushTarget(
    targetId: "<TARGET_ID>",
    identifier: "<IDENTIFIER>",
    providerId: "<PROVIDER_ID>" // optional
);
```
