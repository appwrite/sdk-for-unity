```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

TablesDB tablesDB = new TablesDB(client);

Row result = await tablesDB.GetRow(
    databaseId: "<DATABASE_ID>",
    tableId: "<TABLE_ID>",
    rowId: "<ROW_ID>",
    queries: new List<string>(), // optional
    transactionId: "<TRANSACTION_ID>" // optional
);
```
