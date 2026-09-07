```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

VectorsDB vectorsDB = new VectorsDB(client);

Transaction result = await vectorsDB.UpdateTransaction(
    transactionId: "<TRANSACTION_ID>",
    commit: false, // optional
    rollback: false // optional
);
```
