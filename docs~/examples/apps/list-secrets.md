```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

AppSecretList result = await apps.ListSecrets(
    appId: "<APP_ID>",
    queries: new List<string>(), // optional
    total: false // optional
);
```
