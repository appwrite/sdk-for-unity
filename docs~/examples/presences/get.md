```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Presences presences = new Presences(client);

Presence result = await presences.Get(
    presenceId: "<PRESENCE_ID>"
);
```
