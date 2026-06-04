```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

TablesDB tablesDB = new TablesDB(client);

Transaction result = await tablesDB.GetTransaction(
    transactionId: "<TRANSACTION_ID>"
);
```
