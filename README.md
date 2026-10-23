# Appwrite Unity SDK

![License](https://img.shields.io/badge/license-BSD--3--Clause-blue.svg?style=flat-square)
![Version](https://img.shields.io/badge/api%20version-2.6.1-blue.svg?style=flat-square)
![Unity](https://img.shields.io/badge/Unity-2021.3%2B-blue.svg?style=flat-square)
[![X Account](https://img.shields.io/badge/follow-%40appwrite-000000?logo=x&style=flat-square)](https://x.com/appwrite)
[![Discord](https://img.shields.io/discord/564160730845151244?label=discord&style=flat-square)](https://appwrite.io/discord)

**This SDK targets Appwrite server version 2.6.x as shipped on Appwrite Cloud.** Self-hosted releases can lag behind Cloud — if you run an older self-hosted build, use a matching older SDK from [previous releases](https://github.com/appwrite/sdk-for-unity/releases) when APIs differ.

Appwrite is an open-source backend as a service server that abstracts and simplifies complex and repetitive development tasks behind a very simple to use REST API. Appwrite aims to help you develop your apps faster and in a more secure way. Use the Unity SDK to integrate your app with the Appwrite server to easily start interacting with all of Appwrite backend APIs and tools. For full API documentation and tutorials go to [https://appwrite.io/docs](https://appwrite.io/docs)


## Installation

Requires Unity 2021.3 or later. Installing from a git URL also requires [Git](https://git-scm.com/downloads) on your `PATH`.

### Unity Package Manager (UPM)

1. In Unity, open **Window > Package Manager**.
2. Click the **+** button and select **Add package from git URL** (**Install package from git URL** in Unity 6).
3. Enter the following URL and click **Add** (**Install** in Unity 6):

```text
https://github.com/appwrite/sdk-for-unity.git#0.11.1
```

The `#0.11.1` suffix pins the package to a release. Change it to any released tag, or omit it to track the latest commit on the default branch.

You can also add the package to `Packages/manifest.json` directly:

```json
{
  "dependencies": {
    "io.appwrite.unity": "https://github.com/appwrite/sdk-for-unity.git#0.11.1"
  }
}
```

### Install from disk

1. Download the source code archive of a release from [GitHub](https://github.com/appwrite/sdk-for-unity/releases) and extract it.
2. In **Window > Package Manager**, click the **+** button and select **Add package from disk** (**Install package from disk** in Unity 6).
3. Select the `package.json` file in the extracted folder.

## OAuth on Android

OAuth sign-in returns to your app through the `appwrite-callback-<PROJECT_ID>` URL scheme. When you build for Android, the package registers this scheme on the Unity activity for the project ID set on each `AppwriteConfig` asset in your project, so you do not need to edit any manifest.

If you create the client in code without a `AppwriteConfig` asset, enable **Custom Main Manifest** in **Project Settings > Player > Android > Publishing Settings** and add this intent filter to the Unity activity in `Assets/Plugins/Android/AndroidManifest.xml`, replacing `<PROJECT_ID>` with your project ID:

```xml
<intent-filter>
    <action android:name="android.intent.action.VIEW" />
    <category android:name="android.intent.category.DEFAULT" />
    <category android:name="android.intent.category.BROWSABLE" />
    <data android:scheme="appwrite-callback-<PROJECT_ID>" />
</intent-filter>
```

## Getting Started

### Install dependencies

The SDK depends on two packages that are installed separately:

- [**UniTask**](https://github.com/Cysharp/UniTask) for async/await support.
- [**NativeWebSocket**](https://github.com/endel/NativeWebSocket) for realtime subscriptions.

When you first import the SDK, the **Appwrite Setup Assistant** opens and offers to install them. You can reopen it at any time from **Appwrite > Setup Assistant**. The SDK's runtime code stays disabled until UniTask is installed. `System.Text.Json` and its dependencies ship with the SDK as DLLs.

### Configure your project

Create a project in the [Appwrite Console](https://cloud.appwrite.io/). Find your endpoint and project ID in the project's **Settings** page.

If you build for WebGL, add a **Web** platform to your project with the hostname that serves your build, so Appwrite accepts requests from it.

Then create an `AppwriteConfig` asset with **Appwrite > Create Configuration**, or click **Setup Current Scene** in the Setup Assistant to create the asset and add an `AppwriteManager` to the open scene. Set the endpoint (for example `https://<REGION>.cloud.appwrite.io/v1`), your project ID, and the services you want `AppwriteManager` to create.

### Make your first request with AppwriteManager

`AppwriteManager` creates the client and the services selected in your configuration, and can open the realtime connection.

```csharp
using Appwrite;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AppwriteExample : MonoBehaviour
{
    [SerializeField] private AppwriteConfig config;

    private RealtimeSubscription subscription;

    private async void Start()
    {
        var manager = AppwriteManager.Instance;
        if (manager == null)
        {
            manager = new GameObject("AppwriteManager").AddComponent<AppwriteManager>();
        }

        manager.SetConfig(config);

        if (!await manager.Initialize(needRealtime: true))
        {
            Debug.LogError("Failed to initialize AppwriteManager");
            return;
        }

        var tablesDB = manager.GetService<TablesDB>();
        var rows = await tablesDB.ListRows(
            databaseId: "<DATABASE_ID>",
            tableId: "<TABLE_ID>");
        Debug.Log($"Found {rows.Total} rows");

        subscription = manager.Realtime.Subscribe(
            Channel.TablesDB("<DATABASE_ID>").Table("<TABLE_ID>").Row(),
            response => Debug.Log($"Realtime event: {response.Events[0]}"));
    }

    private void OnDestroy()
    {
        subscription?.Close();
    }
}
```

`GetService<T>()` throws if the service is not selected in your `AppwriteConfig`.

### Using the client directly

You can also create a client and services yourself, without `AppwriteManager`:

```csharp
var client = Client.From(
    projectId: "<PROJECT_ID>",
    endpoint: "https://<REGION>.cloud.appwrite.io/v1");

var account = new Account(client);
var session = await account.CreateAnonymousSession();
Debug.Log($"Signed in as {session.UserId}");
```

`Client.FromSession`, `Client.FromJWT` and `Client.FromImpersonation` create clients that are already authenticated.

### OAuth sign-in

`account.CreateOAuth2Session()` opens the provider's sign-in page and waits for Appwrite to redirect back to your app on the `appwrite-callback-<PROJECT_ID>` URL scheme. Appwrite accepts this scheme for your project without extra Console setup, but your build must handle it:

- **Android**: see [OAuth on Android](#oauth-on-android).
- **iOS**: add `appwrite-callback-<PROJECT_ID>` to **Supported URL schemes** under **Project Settings > Player > iOS > Other Settings**.
- **WebGL**: not supported. The sign-in page replaces your build in the same tab, and a browser cannot return to it on the callback scheme, so the call never completes. Use another sign-in method, such as email and password, in WebGL builds.

### Error handling

The SDK throws an `AppwriteException` when a request fails. It exposes `Message`, `Code`, `Type`, and `Response` properties that you can use to inspect the error.

```csharp
try
{
    var user = await account.Get();
}
catch (AppwriteException ex)
{
    Debug.LogError($"Appwrite error: {ex.Message}");
    Debug.LogError($"Status code: {ex.Code}");
    Debug.LogError($"Response: {ex.Response}");
}
```

### Preparing models for TablesDB

The SDK serializes request data with `System.Text.Json` and converts property names from `PascalCase` to `camelCase`. If your table's column names are not in `camelCase`, the serialized names will not match your columns.

Add the `JsonPropertyName` attribute to each property of your model so it serializes to the column name:

```csharp
using System.Text.Json.Serialization;

public class Movie
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("release_date")]
    public System.DateTime ReleaseDate { get; set; }
}
```

### Learn more
You can use the following resources to learn more and get help:

- 🚀 [Appwrite Quick Starts](https://appwrite.io/docs/quick-starts)
- 📜 [Appwrite Docs](https://appwrite.io/docs)
- 💬 [Discord Community](https://appwrite.io/discord)

## Contribution

This library is auto-generated by the Appwrite [SDK Generator](https://github.com/appwrite/sdk-generator). To learn how you can help improve this SDK, please check the [contribution guide](https://github.com/appwrite/sdk-generator/blob/main/CONTRIBUTING.md) before sending a pull request.

## License

Please see the [BSD-3-Clause license](https://raw.githubusercontent.com/appwrite/appwrite/master/LICENSE) file for more information.

## Changelog

Please see [CHANGELOG](CHANGELOG.md) for more information about recent changes.
