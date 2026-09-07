```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

Oauth2ConsentList result = await account.ListConsents(
    queries: new List<string>(), // optional
    total: false // optional
);
```
