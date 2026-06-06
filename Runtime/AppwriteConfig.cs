using System;
using UnityEngine;

namespace Appwrite
{
    // Define the service enum with Flags attribute for multi-selection in the inspector
    [Flags]
    public enum AppwriteService
    {
        None = 0,
        Account = 1 << 0,
        Apps = 1 << 1,
        Avatars = 1 << 2,
        Databases = 1 << 3,
        Functions = 1 << 4,
        Graphql = 1 << 5,
        Locale = 1 << 6,
        Messaging = 1 << 7,
        Oauth2 = 1 << 8,
        Presences = 1 << 9,
        Storage = 1 << 10,
        TablesDB = 1 << 11,
        Teams = 1 << 12,

        [Tooltip("Selects all available services.")]
        All = Account | Apps | Avatars | Databases | Functions | Graphql | Locale | Messaging | Oauth2 | Presences | Storage | TablesDB | Teams
    }

    /// <summary>
    /// ScriptableObject configuration for Appwrite client settings
    /// </summary>
    [CreateAssetMenu(fileName = "AppwriteConfig", menuName = "Appwrite/Configuration")]
    public class AppwriteConfig : ScriptableObject
    {
        [Header("Connection Settings")]
        [Tooltip("Endpoint URL for Appwrite API (e.g., https://cloud.appwrite.io/v1)")]
        [SerializeField] private string endpoint = "https://cloud.appwrite.io/v1";
        
        [Tooltip("WebSocket endpoint for realtime updates (optional)")]
        [SerializeField] private string realtimeEndpoint = "wss://cloud.appwrite.io/v1";
        
        [Tooltip("Enable if using a self-signed SSL certificate")]
        [SerializeField] private bool selfSigned;
        
        [Header("Project Settings")]
        [Tooltip("Your Appwrite project ID")]
        [SerializeField] private string projectId = "";

        [Header("Service Initialization")] 
        [Tooltip("Select which Appwrite services to initialize.")]
        [SerializeField] private AppwriteService servicesToInitialize = AppwriteService.All;
        
        [Header("Advanced Settings")]
        [Tooltip("Dev key (optional). Dev keys allow bypassing rate limits and CORS errors in your development environment. WARNING: Storing dev keys in ScriptableObjects is a security risk. Do not expose this in public repositories. Consider loading from a secure location at runtime for production builds.")]
        [SerializeField] private string devKey = "";

        [Tooltip("Automatically connect to Appwrite on start")]
        [SerializeField] private bool autoConnect;

        public string Endpoint => endpoint;
        public string RealtimeEndpoint => realtimeEndpoint;
        public bool SelfSigned => selfSigned;
        public string ProjectId => projectId;
        public string DevKey => devKey;
        public bool AutoConnect => autoConnect;
        public AppwriteService ServicesToInitialize => servicesToInitialize;

        /// <summary>
        /// Validate configuration settings
        /// </summary>
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(endpoint))
                Debug.LogWarning("AppwriteConfig: Endpoint is required");
            
            if (string.IsNullOrEmpty(projectId))
                Debug.LogWarning("AppwriteConfig: Project ID is required");

            if (!string.IsNullOrEmpty(devKey))
                Debug.LogWarning("AppwriteConfig: Dev Key is set. For security, avoid storing keys directly in assets for production builds.");
        }
        
        
        /// <summary>
        /// Create a client using this configuration.
        /// </summary>
        public Client CreateClient()
        {
            return string.IsNullOrEmpty(devKey)
                ? Client.From(
                    projectId: projectId,
                    endpoint: endpoint,
                    endpointRealtime: string.IsNullOrEmpty(realtimeEndpoint) ? null : realtimeEndpoint,
                    selfSigned: selfSigned)
                : Client.FromDevKey(
                    projectId: projectId,
                    devKey: devKey,
                    endpoint: endpoint,
                    endpointRealtime: string.IsNullOrEmpty(realtimeEndpoint) ? null : realtimeEndpoint,
                    selfSigned: selfSigned);
        }

        #if UNITY_EDITOR
        [UnityEditor.MenuItem("Appwrite/Create Configuration")]
        public static AppwriteConfig CreateConfiguration()
        {
            var config = CreateInstance<AppwriteConfig>();
            
            if (!System.IO.Directory.Exists("Assets/Appwrite"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Appwrite");
            }
            if (!System.IO.Directory.Exists("Assets/Appwrite/Resources"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets/Appwrite", "Resources");
            }
            
            string path = "Assets/Appwrite/Resources/AppwriteConfig.asset";
            path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath(path);
                
            UnityEditor.AssetDatabase.CreateAsset(config, path);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.EditorUtility.FocusProjectWindow();
            UnityEditor.Selection.activeObject = config;

            Debug.Log($"Appwrite configuration created at: {path}");
            
            return config;
        }
        #endif
    }
}