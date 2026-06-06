```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Avatars avatars = new Avatars(client);

byte[] result = await avatars.GetBrowser(
    code: Browser.AvantBrowser,
    width: 0, // optional
    height: 0, // optional
    quality: -1 // optional
);
```
