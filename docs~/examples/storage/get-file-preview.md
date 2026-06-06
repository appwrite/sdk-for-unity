```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Storage storage = new Storage(client);

byte[] result = await storage.GetFilePreview(
    bucketId: "<BUCKET_ID>",
    fileId: "<FILE_ID>",
    width: 0, // optional
    height: 0, // optional
    gravity: ImageGravity.Center, // optional
    quality: -1, // optional
    borderWidth: 0, // optional
    borderColor: "", // optional
    borderRadius: 0, // optional
    opacity: 0, // optional
    rotation: -360, // optional
    background: "", // optional
    output: ImageFormat.Jpg, // optional
    token: "<TOKEN>" // optional
);
```
