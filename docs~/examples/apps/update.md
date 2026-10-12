```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;

Client client = Client.From(
    projectId: "<YOUR_PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

Apps apps = new Apps(client);

App result = await apps.Update(
    appId: "<APP_ID>",
    name: "<NAME>",
    description: "<DESCRIPTION>", // optional
    clientUri: "https://example.com", // optional
    logoUri: "https://example.com", // optional
    privacyPolicyUrl: "https://example.com", // optional
    termsUrl: "https://example.com", // optional
    contacts: new List<string>(), // optional
    tagline: "<TAGLINE>", // optional
    tags: new List<string>(), // optional
    images: new List<string>(), // optional
    supportUrl: "https://example.com", // optional
    dataDeletionUrl: "https://example.com", // optional
    enabled: false, // optional
    redirectUris: new List<string>(), // optional
    postLogoutRedirectUris: new List<string>(), // optional
    type: "public", // optional
    deviceFlow: false, // optional
    installationScopes: new List<string>(), // optional
    installationRedirectUrl: "https://example.com" // optional
);
```
