```csharp
using System.Collections.Generic;
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Videos videos = new Videos(client);

VideoRenditionList result = await videos.ListRenditions(
    videoId: "<VIDEO_ID>",
    queries: new List<string>(), // optional
    total: false // optional
);
```
