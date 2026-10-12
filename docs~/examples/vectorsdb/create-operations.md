```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

VectorsDB vectorsDB = new VectorsDB(client);

Transaction result = await vectorsDB.CreateOperations(
    transactionId: "<TRANSACTION_ID>",
    operations: [
	    {
	        "action": "create",
	        "databaseId": "<DATABASE_ID>",
	        "collectionId": "<COLLECTION_ID>",
	        "documentId": "<DOCUMENT_ID>",
	        "data": {
	            "embeddings": [
	                0.12,
	                -0.55,
	                0.88,
	                1.02
	            ],
	            "metadata": {
	                "name": "First document"
	            }
	        }
	    }
	] // optional
);
```
