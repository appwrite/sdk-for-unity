```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Oauth2 oauth2 = new Oauth2(client);

Oauth2Token result = await oauth2.CreateToken(
    grant_type: "<GRANT_TYPE>",
    code: "<CODE>", // optional
    refresh_token: "<REFRESH_TOKEN>", // optional
    device_code: "<DEVICE_CODE>", // optional
    client_id: "<CLIENT_ID>", // optional
    client_secret: "<CLIENT_SECRET>", // optional
    code_verifier: "<CODE_VERIFIER>", // optional
    redirect_uri: "https://example.com", // optional
    resource: new List<string>(), // optional
    audience: "<AUDIENCE>" // optional
);
```
