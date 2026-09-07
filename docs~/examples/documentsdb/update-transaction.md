```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

DocumentsDB documentsDB = new DocumentsDB(client);

Transaction result = await documentsDB.UpdateTransaction(
    transactionId: "<TRANSACTION_ID>",
    commit: false, // optional
    rollback: false // optional
);
```
