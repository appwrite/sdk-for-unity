```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Teams teams = new Teams(client);

AppInstallation result = await teams.UpdateInstallation(
    teamId: "<TEAM_ID>",
    installationId: "<INSTALLATION_ID>",
    authorizationDetails: "<AUTHORIZATION_DETAILS>" // optional
);
```
