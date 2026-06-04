```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

TablesDB tablesDB = new TablesDB(client);

RowList result = await tablesDB.ListRows(
    databaseId: "<DATABASE_ID>",
    tableId: "<TABLE_ID>",
    queries: new List<string>(), // optional
    transactionId: "<TRANSACTION_ID>", // optional
    total: false, // optional
    ttl: 0 // optional
);
```
