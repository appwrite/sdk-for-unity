```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Oauth2 oauth2 = new Oauth2(client);

Oauth2Approve result = await oauth2.Approve(
    project_id: "<PROJECT_ID>",
    grant_id: "<GRANT_ID>",
    authorization_details: "<AUTHORIZATION_DETAILS>" // optional
);
```
