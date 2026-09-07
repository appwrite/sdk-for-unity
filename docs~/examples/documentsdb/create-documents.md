```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

DocumentsDB documentsDB = new DocumentsDB(client);

DocumentList result = await documentsDB.CreateDocuments(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    documents: new List<object>(),
    transactionId: "<TRANSACTION_ID>" // optional
);
```
