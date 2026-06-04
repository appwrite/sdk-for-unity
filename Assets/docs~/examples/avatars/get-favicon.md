```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Avatars avatars = new Avatars(client);

byte[] result = await avatars.GetFavicon(
    url: "https://example.com"
);
```
