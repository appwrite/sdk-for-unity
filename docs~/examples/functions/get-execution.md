```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Functions functions = new Functions(client);

Execution result = await functions.GetExecution(
    functionId: "<FUNCTION_ID>",
    executionId: "<EXECUTION_ID>"
);
```
