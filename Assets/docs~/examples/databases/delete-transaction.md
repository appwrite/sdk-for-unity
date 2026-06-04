```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Databases databases = new Databases(client);

await databases.DeleteTransaction(
    transactionId: "<TRANSACTION_ID>"
);
```
