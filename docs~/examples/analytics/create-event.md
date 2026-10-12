```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Analytics analytics = new Analytics(client);

object result = await analytics.CreateEvent(
    propertyId: "<PROPERTY_ID>",
    name: "<NAME>",
    url: "https://example.com",
    domain: "<DOMAIN>", // optional
    referrer: "<REFERRER>", // optional
    screenWidth: 0, // optional
    sessionHash: "<SESSION_HASH>", // optional
    scrollDepth: 0, // optional
    engagementTime: 0, // optional
    props: new List<string>(), // optional
    userId: "<USER_ID>", // optional
    ip: "<IP>", // optional
    userAgent: "<USER_AGENT>" // optional
);
```
