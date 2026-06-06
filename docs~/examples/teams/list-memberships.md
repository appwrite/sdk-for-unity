```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Teams teams = new Teams(client);

MembershipList result = await teams.ListMemberships(
    teamId: "<TEAM_ID>",
    queries: new List<string>(), // optional
    search: "<SEARCH>", // optional
    total: false // optional
);
```
