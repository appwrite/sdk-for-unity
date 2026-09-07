```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

VectorsDB vectorsDB = new VectorsDB(client);

Document result = await vectorsDB.CreateDocument(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    documentId: "<DOCUMENT_ID>",
    data: new {
        embeddings = new[] { 0.12, -0.55, 0.88, 1.02 },
        metadata = { key = "value" }
    },
    permissions: new List<string> { Permission.Read(Role.Any()) }, // optional
    transactionId: "<TRANSACTION_ID>" // optional
);
```
