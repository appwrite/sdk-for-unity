```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Presences presences = new Presences(client);

Presence result = await presences.Upsert(
    presenceId: "<PRESENCE_ID>",
    status: "<STATUS>",
    permissions: new List<string> { Permission.Read(Role.Any()) }, // optional
    expiresAt: "2020-10-15T06:38:00.000+00:00", // optional
    metadata: [object] // optional
);
```
