```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Account account = new Account(client);

TokenSecret result = await account.UpdatePasskeyToken(
    challengeId: "<CHALLENGE_ID>",
    credential: [object]
);
```
