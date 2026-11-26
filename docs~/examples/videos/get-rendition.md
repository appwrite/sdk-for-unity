```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Videos videos = new Videos(client);

VideoRendition result = await videos.GetRendition(
    videoId: "<VIDEO_ID>",
    renditionId: "<RENDITION_ID>"
);
```
