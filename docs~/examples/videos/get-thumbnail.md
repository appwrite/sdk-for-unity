```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Videos videos = new Videos(client);

byte[] result = await videos.GetThumbnail(
    videoId: "<VIDEO_ID>",
    thumbnailId: "<THUMBNAIL_ID>",
    width: 0, // optional
    height: 0, // optional
    output: ImageFormat.Jpg // optional
);
```
