```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Avatars avatars = new Avatars(client);

byte[] result = await avatars.GetQR(
    text: "<TEXT>",
    size: 1, // optional
    margin: 0, // optional
    download: false // optional
);
```
