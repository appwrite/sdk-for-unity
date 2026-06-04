```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Databases databases = new Databases(client);

Document result = await databases.DecrementDocumentAttribute(
    databaseId: "<DATABASE_ID>",
    collectionId: "<COLLECTION_ID>",
    documentId: "<DOCUMENT_ID>",
    attribute: "",
    value: 0, // optional
    min: 0, // optional
    transactionId: "<TRANSACTION_ID>" // optional
);
```
