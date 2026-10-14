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
        Analytics = 1 << 1,
        Apps = 1 << 2,
        Avatars = 1 << 3,
        Databases = 1 << 4,
        DocumentsDB = 1 << 5,
        Functions = 1 << 6,
        Graphql = 1 << 7,
        Locale = 1 << 8,
        Messaging = 1 << 9,
        Oauth2 = 1 << 10,
        Organization = 1 << 11,
        Presences = 1 << 12,
        Storage = 1 << 13,
        TablesDB = 1 << 14,
        Teams = 1 << 15,
        VectorsDB = 1 << 16,

        [Tooltip("Selects all available services.")]
        All = Account | Analytics | Apps | Avatars | Databases | DocumentsDB | Functions | Graphql | Locale | Messaging | Oauth2 | Organization | Presences | Storage | TablesDB | Teams | VectorsDB
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
        [Tooltip("Automatically connect to Appwrite on start")]
        [SerializeField] private bool autoConnect;

        public string Endpoint => endpoint;
        public string RealtimeEndpoint => realtimeEndpoint;
        public bool SelfSigned => selfSigned;
        public string ProjectId => projectId;
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
        }


        /// <summary>
        /// Create a client using this configuration.
        /// </summary>
        public Client CreateClient()
        {
            return Client.From(
                projectId: projectId,
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
