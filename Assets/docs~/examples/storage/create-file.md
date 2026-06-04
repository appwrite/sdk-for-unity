```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Storage storage = new Storage(client);

File result = await storage.CreateFile(
    bucketId: "<BUCKET_ID>",
    fileId: "<FILE_ID>",
    file: InputFile.FromPath("./path-to-files/image.jpg"),
    permissions: new List<string> { Permission.Read(Role.Any()) } // optional
);
```
