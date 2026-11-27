```csharp
using System.Collections.Generic;
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Videos videos = new Videos(client);

Video result = await videos.Create(
    videoId: "<VIDEO_ID>",
    bucketId: "<BUCKET_ID>",
    fileId: "<FILE_ID>",
    name: "<NAME>", // optional
    permissions: new List<string> { Permission.Read(Role.Any()) } // optional
);
```
