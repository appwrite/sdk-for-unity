#if UNI_TASK
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Appwrite.Utilities
{
    /// <summary>
    /// Utility class for Appwrite Unity integration
    /// </summary>
    public static class AppwriteUtilities
    {
        #if UNITY_EDITOR
        /// <summary>
        /// Quick setup for Appwrite in Unity (Editor Only)
        /// </summary>
        public static async UniTask<AppwriteManager> QuickSetup()
        {
            // Create configuration
            var config = AppwriteConfig.CreateConfiguration();
            

            // Create manager
            var managerGO = new GameObject("AppwriteManager");
            var manager = managerGO.AddComponent<AppwriteManager>();
            manager.SetConfig(config);

            // Initialize
            var success = await manager.Initialize(true);
            if (!success)
            {
                UnityEngine.Object.Destroy(managerGO);
                throw new InvalidOperationException("Failed to initialize AppwriteManager");
            }
            //Create Realtime instance
            var a =manager.Realtime;
            return manager;
        }
        #endif

        /// <summary>
        /// Run async operation with Unity-safe error handling
        /// </summary>
        public static async UniTask<T> SafeExecute<T>(
            Func<UniTask<T>> operation,
            T defaultValue = default,
            bool logErrors = true)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                if (logErrors)
                    Debug.LogError($"Appwrite operation failed: {ex.Message}");
                return defaultValue;
            }
        }

        /// <summary>
        /// Run async operation with Unity-safe error handling (no return value)
        /// </summary>
        public static async UniTask SafeExecute(
            Func<UniTask> operation,
            bool logErrors = true)
        {
            try
            {
                await operation();
            }
            catch (Exception ex)
            {
                if (logErrors)
                    Debug.LogError($"Appwrite operation failed: {ex.Message}");
            }
        }
    }
}
#endif
