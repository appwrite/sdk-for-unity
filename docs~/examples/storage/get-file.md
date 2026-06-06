```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Storage storage = new Storage(client);

File result = await storage.GetFile(
    bucketId: "<BUCKET_ID>",
    fileId: "<FILE_ID>"
);
```
