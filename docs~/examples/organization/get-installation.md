```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Organization organization = new Organization(client);

AppInstallation result = await organization.GetInstallation(
    installationId: "<INSTALLATION_ID>"
);
```
