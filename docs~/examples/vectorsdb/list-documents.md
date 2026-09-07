```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

VectorsDB vectorsDB = new VectorsDB(client);

DocumentList result = await vectorsDB.ListDocuments(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    queries: new List<string>(), // optional
    transactionId: "<TRANSACTION_ID>", // optional
    total: false, // optional
    ttl: 0 // optional
);
```
