```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Storage storage = new Storage(client);

FileList result = await storage.ListFiles(
    bucketId: "<BUCKET_ID>",
    queries: new List<string>(), // optional
    search: "<SEARCH>", // optional
    total: false // optional
);
```
