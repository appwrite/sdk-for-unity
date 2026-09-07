```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Teams teams = new Teams(client);

AppInstallation result = await teams.CreateInstallation(
    teamId: "<TEAM_ID>",
    appId: "<APP_ID>",
    authorizationDetails: "<AUTHORIZATION_DETAILS>" // optional
);
```
