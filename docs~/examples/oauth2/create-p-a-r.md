```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Oauth2 oauth2 = new Oauth2(client);

Oauth2PAR result = await oauth2.CreatePAR(
    client_id: "<CLIENT_ID>",
    redirect_uri: "https://example.com",
    response_type: "code",
    scope: "<SCOPE>", // optional
    state: "<STATE>", // optional
    nonce: "<NONCE>", // optional
    code_challenge: "<CODE_CHALLENGE>", // optional
    code_challenge_method: "s256", // optional
    prompt: "<PROMPT>", // optional
    max_age: 0, // optional
    authorization_details: "<AUTHORIZATION_DETAILS>", // optional
    resource: new List<string>(), // optional
    audience: "<AUDIENCE>" // optional
);
```
