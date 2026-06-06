```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Teams teams = new Teams(client);

Membership result = await teams.CreateMembership(
    teamId: "<TEAM_ID>",
    roles: new List<string>(),
    email: "email@example.com", // optional
    userId: "<USER_ID>", // optional
    phone: "+12065550100", // optional
    url: "https://example.com", // optional
    name: "<NAME>" // optional
);
```
