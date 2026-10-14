```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

AppInstallation result = await apps.GetInstallation(
    appId: "<APP_ID>",
    installationId: "<INSTALLATION_ID>"
);
```
