```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Oauth2 oauth2 = new Oauth2(client);

object result = await oauth2.Logout(
    id_token_hint: "<ID_TOKEN_HINT>", // optional
    logout_hint: "<LOGOUT_HINT>", // optional
    client_id: "<CLIENT_ID>", // optional
    post_logout_redirect_uri: "https://example.com", // optional
    state: "<STATE>", // optional
    ui_locales: "<UI_LOCALES>" // optional
);
```
