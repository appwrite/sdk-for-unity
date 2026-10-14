```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

Oauth2Token result = await apps.CreateInstallationToken(
    appId: "<APP_ID>",
    installationId: "<INSTALLATION_ID>"
);
```
