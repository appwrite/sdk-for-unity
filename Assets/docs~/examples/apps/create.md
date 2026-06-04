```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

App result = await apps.Create(
    appId: "<APP_ID>",
    name: "<NAME>",
    redirectUris: new List<string>(),
    enabled: false, // optional
    internal: false, // optional
    type: "public", // optional
    teamId: "<TEAM_ID>" // optional
);
```
