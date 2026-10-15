```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Oauth2 oauth2 = new Oauth2(client);

object result = await oauth2.Revoke(
    token: "<TOKEN>",
    token_type_hint: "access_token", // optional
    client_id: "<CLIENT_ID>", // optional
    client_secret: "<CLIENT_SECRET>" // optional
);
```
