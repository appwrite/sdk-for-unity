```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Functions functions = new Functions(client);

ExecutionList result = await functions.ListExecutions(
    functionId: "<FUNCTION_ID>",
    queries: new List<string>(), // optional
    total: false // optional
);
```
