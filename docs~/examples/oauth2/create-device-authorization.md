```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Oauth2 oauth2 = new Oauth2(client);

Oauth2DeviceAuthorization result = await oauth2.CreateDeviceAuthorization(
    client_id: "<CLIENT_ID>", // optional
    scope: "<SCOPE>", // optional
    authorization_details: "<AUTHORIZATION_DETAILS>", // optional
    resource: new List<string>(), // optional
    audience: "<AUDIENCE>" // optional
);
```
