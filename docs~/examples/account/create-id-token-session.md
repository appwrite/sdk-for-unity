```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

Session result = await account.CreateIdTokenSession(
    provider: IdTokenProvider.Apple,
    idToken: "<ID_TOKEN>",
    nonce: "<NONCE>", // optional
    accessToken: "<ACCESS_TOKEN>", // optional
    accessTokenExpiry: 0, // optional
    name: "<NAME>" // optional
);
```
