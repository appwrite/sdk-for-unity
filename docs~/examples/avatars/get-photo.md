```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Avatars avatars = new Avatars(client);

byte[] result = await avatars.GetPhoto(
    width: 0, // optional
    height: 0, // optional
    quality: 0, // optional
    output: "png", // optional
    rating: "g", // optional
    userId: "current()", // optional
    emailHash: "<EMAIL_HASH>", // optional
    name: "<NAME>" // optional
);
```
