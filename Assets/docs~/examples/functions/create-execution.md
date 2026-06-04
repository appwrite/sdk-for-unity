```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Functions functions = new Functions(client);

Execution result = await functions.CreateExecution(
    functionId: "<FUNCTION_ID>",
    body: "<BODY>", // optional
    async: false, // optional
    path: "<PATH>", // optional
    method: ExecutionMethod.GET, // optional
    headers: [object], // optional
    scheduledAt: "<SCHEDULED_AT>" // optional
);
```
