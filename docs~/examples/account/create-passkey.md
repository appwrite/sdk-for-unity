```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

PasskeyChallenge result = await account.CreatePasskey(
    passkeyId: "<PASSKEY_ID>", // optional
    name: "<NAME>" // optional
);
```
