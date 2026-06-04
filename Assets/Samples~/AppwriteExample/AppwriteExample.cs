using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Samples.AppwriteExample
{
    /// <summary>
    /// Example of how to use Appwrite with Unity integration
    /// </summary>
    public class AppwriteExample : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private AppwriteConfig config;
        
        private AppwriteManager _manager;
        
        private async void Start()
        
        {
            // Method 1: Using AppwriteManager (Recommended)
            await ExampleWithManager();
            
            // Method 2: Using Client directly
            await ExampleWithDirectClient();
        }
        
        /// <summary>
        /// Example using AppwriteManager for easy setup
        /// </summary>
        private async UniTask ExampleWithManager()
        {
            Debug.Log("=== Example with AppwriteManager ===");
            
            // Get or create manager
            _manager = AppwriteManager.Instance;
            if (_manager == null)
            {
                var managerGo = new GameObject("AppwriteManager");
                _manager = managerGo.AddComponent<AppwriteManager>();
                _manager.SetConfig(config);
            }
            
            // Initialize
            var success = await _manager.Initialize(true);
            if (!success)
            {
                Debug.LogError("Failed to initialize AppwriteManager");
                return;
            }
            
            // Use services through manager
            try
            {
                // Direct client access
                var client = _manager.Client;
                var pingResult = await client.Ping();
                Debug.Log($"Ping result: {pingResult}");
                
                // Service creation through DI container
                // var account = _manager.GetService<Account>();
                // var databases = _manager.GetService<Databases>();
                
                // Realtime example
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
                
                Debug.Log("AppwriteManager example completed successfully");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"AppwriteManager example failed: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Example using Client directly
        /// </summary>
        private async UniTask ExampleWithDirectClient()
        {
            Debug.Log("=== Example with Direct Client ===");
            
            try
            {
                // Create and configure client
                var client = config.CreateClient();

                // Test connection
                var pingResult = await client.Ping();
                Debug.Log($"Direct client ping: {pingResult}");

                // Create services manually
                // var account = new Account(client);
                // var databases = new Databases(client);

                // Realtime example
                // You need to create a Realtime instance manually or attach dependently
                // realtime.Initialize(client);
                // var subscription = realtime.Subscribe(
                //     new[] { "databases.*.collections.*.documents" },
                //     response =>
                //     {
                //         var eventName = response.Events != null && response.Events.Length > 0
                //             ? response.Events[0]
                //             : "unknown";
                //
                //         Debug.Log($"Realtime event: {eventName}");
                //     }
                // );

                Debug.Log("Direct client example completed successfully");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Direct client example failed: {ex.Message}");
            }
        }
    }
}
