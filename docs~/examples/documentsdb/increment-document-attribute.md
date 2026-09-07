```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

DocumentsDB documentsDB = new DocumentsDB(client);

Document result = await documentsDB.IncrementDocumentAttribute(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    documentId: "<DOCUMENT_ID>",
    attribute: "<ATTRIBUTE>",
    value: 1, // optional
    max: 100, // optional
    transactionId: "<TRANSACTION_ID>" // optional
);
```
