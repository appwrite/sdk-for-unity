```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Presences presences = new Presences(client);

PresenceList result = await presences.List(
    queries: new List<string>(), // optional
    total: false, // optional
    ttl: 0 // optional
);
```
