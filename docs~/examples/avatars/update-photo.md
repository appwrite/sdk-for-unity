```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Avatars avatars = new Avatars(client);

Account result = await avatars.UpdatePhoto(
    file: InputFile.FromPath("./path-to-files/image.jpg")
);
```
