```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

await account.CreateOAuth2Token(
    provider: OAuthProvider.Amazon,
    success: "https://example.com", // optional
    failure: "https://example.com", // optional
    scopes: new List<string>() // optional
);
```
