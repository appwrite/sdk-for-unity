```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Videos videos = new Videos(client);

VideoCaption result = await videos.UpdateCaption(
    videoId: "<VIDEO_ID>",
    captionId: "<CAPTION_ID>",
    bucketId: "<BUCKET_ID>", // optional
    fileId: "<FILE_ID>", // optional
    name: "<NAME>", // optional
    language: "aar", // optional
    default: false // optional
);
```
