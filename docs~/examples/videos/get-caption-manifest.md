```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Videos videos = new Videos(client);

byte[] result = await videos.GetCaptionManifest(
    videoId: "<VIDEO_ID>",
    output: VideoOutput.Hls,
    captionId: "<CAPTION_ID>"
);
```
