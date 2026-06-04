```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

AppSecret result = await apps.GetSecret(
    appId: "<APP_ID>",
    secretId: "<SECRET_ID>"
);
```
