# Appwrite Unity SDK

![License](https://img.shields.io/github/license/appwrite/sdk-for-unity.svg?style=flat-square)
![Version](https://img.shields.io/badge/api%20version-1.9.5-blue.svg?style=flat-square)
![Unity](https://img.shields.io/badge/Unity-2021.3%2B-blue.svg?style=flat-square)
[![Build Status](https://img.shields.io/travis/com/appwrite/sdk-for-unity?style=flat-square)](https://travis-ci.com/appwrite/sdk-for-unity)
[![Twitter Account](https://img.shields.io/twitter/follow/appwrite?color=00acee&label=twitter&style=flat-square)](https://twitter.com/appwrite)
[![Discord](https://img.shields.io/discord/564160730845151244?label=discord&style=flat-square)](https://appwrite.io/discord)

**This SDK is compatible with Appwrite server version 1.9.x. For older versions, please check [previous releases](https://github.com/appwrite/sdk-for-unity/releases).**

Appwrite is an open-source backend as a service server that abstracts and simplifies complex and repetitive development tasks behind a very simple to use REST API. Appwrite aims to help you develop your apps faster and in a more secure way. Use the Unity SDK to integrate your app with the Appwrite server to easily start interacting with all of Appwrite backend APIs and tools. For full API documentation and tutorials go to [https://appwrite.io/docs](https://appwrite.io/docs)


## Installation

### Unity Package Manager (UPM)

1. Open Unity and go to **Window > Package Manager**.
2. Click the **+** button and select **Add package from git URL**.
3. Enter the following URL:

```sh
https://github.com/appwrite/sdk-for-unity.git#0.2.1
```

4. Click **Add**.

The `#0.2.1` suffix pins the package to a specific release. Change it to any released tag, or omit `#0.2.1` to track the latest commit on the default branch.

### Manual Installation

Download the latest release from [GitHub](https://appwrite.io/releases/latest) and import the Unity package into your project.


## Getting Started

Before you begin, create an Appwrite project and add a Unity platform in your Appwrite Console.

This SDK requires the following Unity packages and libraries:

- [**UniTask**](https://github.com/Cysharp/UniTask): For async/await support in Unity.
- [**NativeWebSocket**](https://github.com/endel/NativeWebSocket): For WebSocket realtime subscriptions.
- **System.Text.Json**: For JSON serialization, provided as a DLL in the project.

After installing the SDK, open **Appwrite → Setup Assistant** in Unity and install the required dependencies.

### Configure the SDK

Create an Appwrite configuration using the **QuickStart** window in the **Appwrite Setup Assistant**, or through **Appwrite → Create Configuration**.

### Using AppwriteManager

```csharp
[SerializeField] private AppwriteConfig config;
private AppwriteManager _manager;

private async UniTask ExampleWithManager()
{
    _manager = AppwriteManager.Instance ?? new GameObject("AppwriteManager").AddComponent<AppwriteManager>();
    _manager.SetConfig(config);

    var success = await _manager.Initialize(needRealtime: true);
    if (!success)
    {
        Debug.LogError("Failed to initialize AppwriteManager");
        return;
    }

    var client = _manager.Client;
    var pingResult = await client.Ping();
    Debug.Log($"Ping result: {pingResult}");

    var realtime = _manager.Realtime;
    var subscription = realtime.Subscribe(
        new[] { "databases.*.collections.*.documents" },
        response =>
        {
            var eventName = response.Events != null && response.Events.Length > 0
                ? response.Events[0]
                : "unknown";

            Debug.Log($"Realtime event: {eventName}");
        }
    );

    // Keep a reference to close the subscription when your MonoBehaviour is destroyed.
    // subscription.Close();
}
```

### Using Client directly

```csharp
private async UniTask ExampleWithDirectClient()
{
    var client = Client.From(
        projectId: "<PROJECT_ID>",
        endpoint: "https://<REGION>.cloud.appwrite.io/v1",
        endpointRealtime: "wss://<REGION>.cloud.appwrite.io/v1");

    var pingResult = await client.Ping();
    Debug.Log($"Direct client ping: {pingResult}");
}
```

You can also create authenticated clients with `Client.FromSession`, `Client.FromDevKey`, or `Client.FromImpersonation` when those authentication flows are needed.

### Error handling

```csharp
try
{
    var result = await client.Ping();
}
catch (AppwriteException ex)
{
    Debug.LogError($"Appwrite Error: {ex.Message}");
    Debug.LogError($"Status Code: {ex.Code}");
    Debug.LogError($"Response: {ex.Response}");
}
```

## Preparing Models for Databases API

When working with the Databases API in Unity, models should be prepared for serialization using the System.Text.Json library. System.Text.Json uses CLR property names by default unless a naming policy is configured. If your project or SDK configuration serializes property names differently from your Appwrite collection attributes, this can cause errors due to mismatches between serialized property names and actual attribute names in your collection.

To avoid this, add the `JsonPropertyName` attribute to each property in your model class to match the attribute name in Appwrite:

```csharp
using System.Text.Json.Serialization;

public class TestModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("release_date")]
    public System.DateTime ReleaseDate { get; set; }
}
```

The `JsonPropertyName` attribute ensures your data object is serialized with the correct attribute names for Appwrite databases.

### Learn more
You can use the following resources to learn more and get help:

- 🚀 [Getting Started Tutorial](https://appwrite.io/docs/getting-started-for-client)
- 📜 [Appwrite Docs](https://appwrite.io/docs)
- 💬 [Discord Community](https://appwrite.io/discord)
- 🧰 [Appwrite SDK Generator](https://github.com/appwrite/sdk-generator)


## Contribution

This library is auto-generated by the Appwrite [SDK Generator](https://github.com/appwrite/sdk-for-unity). To learn how you can help improve this SDK, please check the [contribution guide](https://github.com/appwrite/sdk-for-unity/blob/master/CONTRIBUTING.md) before sending a pull request.

## License

Please see the [BSD-3-Clause license](https://raw.githubusercontent.com/appwrite/appwrite/master/LICENSE) file for more information.

## Changelog

Please see [CHANGELOG](CHANGELOG.md) for more information about recent changes.
