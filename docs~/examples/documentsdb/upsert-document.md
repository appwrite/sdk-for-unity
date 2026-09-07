```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

DocumentsDB documentsDB = new DocumentsDB(client);

Document result = await documentsDB.UpsertDocument(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    documentId: "<DOCUMENT_ID>",
    data: [object], // optional
    permissions: new List<string> { Permission.Read(Role.Any()) }, // optional
    transactionId: "<TRANSACTION_ID>" // optional
);
```
