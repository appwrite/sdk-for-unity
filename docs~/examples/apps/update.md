```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

App result = await apps.Update(
    appId: "<APP_ID>",
    name: "<NAME>",
    enabled: false, // optional
    redirectUris: new List<string>(), // optional
    type: "public", // optional
    deviceFlow: false // optional
);
```
