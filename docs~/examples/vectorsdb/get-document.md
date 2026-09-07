```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

VectorsDB vectorsDB = new VectorsDB(client);

Document result = await vectorsDB.GetDocument(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    documentId: "<DOCUMENT_ID>",
    queries: new List<string>(), // optional
    transactionId: "<TRANSACTION_ID>" // optional
);
```
