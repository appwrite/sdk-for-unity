using UnityEngine;
using UnityEditor;
using System;

namespace Appwrite.Editor
{
    public class AppwriteSetupWindow : EditorWindow
    {
        private Vector2 _scrollPosition;
        private string _statusMessage = "";
        private MessageType _statusMessageType = MessageType.Info;
        private bool _isBusy; // Flag to block the UI during asynchronous operations

        private void OnEnable()
        {
            titleContent = new GUIContent("Appwrite Setup", "Appwrite SDK Setup");
            minSize = new Vector2(520, 520);
            maxSize = new Vector2(520, 520);
            RefreshStatus();
        }

        private void OnFocus()
        {
            RefreshStatus();
        }

        // Requests a status refresh and provides a callback to repaint the window
        private void RefreshStatus()
        {
            _isBusy = true;
            Repaint(); // Repaint immediately to show the "Working..." message
            AppwriteSetupAssistant.RefreshPackageStatus(() => {
                _isBusy = false;
                Repaint();
            });
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(20);
            DrawHeader();
            EditorGUILayout.Space(15);

            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            if (!string.IsNullOrEmpty(_statusMessage))
            {
                EditorGUILayout.HelpBox(_statusMessage, _statusMessageType);
                EditorGUILayout.Space(10);
            }

            // Disable the UI while _isBusy = true
            using (new EditorGUI.DisabledScope(_isBusy))
            {
                DrawDependenciesSection();
                EditorGUILayout.Space(15);

                DrawQuickStartSection();
                EditorGUILayout.Space(15);

                DrawActionButtons();
            }

            if (_isBusy)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.HelpBox("Working, please wait...", MessageType.Info);
            }

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(10);
            DrawFooter();
        }

        private void DrawDependenciesSection()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("📦 Dependencies", EditorStyles.boldLabel);

            var missingPackages = !AppwriteSetupAssistant.HasUniTask || !AppwriteSetupAssistant.HasWebSocket;
            if (GUILayout.Button("Install All", GUILayout.Width(100)) && missingPackages)
            {
                _isBusy = true;
                ShowMessage("Installing all required packages...", MessageType.Info);
                // Call the new, reliable method to install packages
                AppwriteSetupAssistant.InstallAllPackages(
                    onSuccess: () => {
                        ShowMessage("All packages installed successfully!", MessageType.Info);
                        RefreshStatus(); // Refresh package statuses and UI after completion
                    },
                    onError: (error) => {
                        ShowMessage($"Failed to install packages: {error}", MessageType.Error);
                        _isBusy = false; // Clear busy flag in case of error
                        Repaint();
                    }
                );
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(10);

            // Pass installation methods to the UI
            DrawPackageStatus("UniTask", AppwriteSetupAssistant.HasUniTask,
                 "Required for async operations",
                 AppwriteSetupAssistant.InstallUniTask);

            EditorGUILayout.Space(5);

            DrawPackageStatus("NativeWebSocket", AppwriteSetupAssistant.HasWebSocket,
                "Required for realtime features",
                AppwriteSetupAssistant.InstallWebSocket);

            EditorGUILayout.Space(5);

            if (!missingPackages && !_isBusy)
            {
                EditorGUILayout.HelpBox("✨ All required packages are installed!", MessageType.Info);
            }

            EditorGUILayout.EndVertical();
        }

        private void DrawPackageStatus(string packageName, bool isInstalled, string description, Action<Action> installAction)
        {
            var boxStyle = new GUIStyle(EditorStyles.helpBox)
            {
                padding = new RectOffset(10, 10, 10, 10),
                margin = new RectOffset(5, 5, 0, 0)
            };

            EditorGUILayout.BeginVertical(boxStyle);
            EditorGUILayout.BeginHorizontal();

            var statusIcon = isInstalled ? "✅" : "⚠️";
            var nameStyle = new GUIStyle(EditorStyles.boldLabel) { fontSize = 12 };
            EditorGUILayout.LabelField($"{statusIcon} {packageName}", nameStyle);

            if (!isInstalled && GUILayout.Button("Install", GUILayout.Width(100)))
            {
                _isBusy = true;
                ShowMessage($"Installing {packageName}...", MessageType.Info);
                installAction?.Invoke(() => { // Invoke installation
                    ShowMessage($"{packageName} installed successfully!", MessageType.Info);
                    RefreshStatus(); // Refresh package statuses and UI after completion
                });
            }

            EditorGUILayout.EndHorizontal();

            if (!isInstalled)
            {
                EditorGUILayout.Space(2);
                var descStyle = new GUIStyle(EditorStyles.miniLabel) { wordWrap = true };
                EditorGUILayout.LabelField(description, descStyle);
            }

            EditorGUILayout.EndVertical();
        }

        private void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            var headerStyle = new GUIStyle(EditorStyles.boldLabel) { fontSize = 16, alignment = TextAnchor.MiddleCenter };
            EditorGUILayout.LabelField("🚀 Appwrite SDK Setup", headerStyle, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(4);
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("Configure your Appwrite SDK for Unity", EditorStyles.centeredGreyMiniLabel, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }
        private void DrawQuickStartSection()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("⚡ Quick Start", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);
            var allPackagesInstalled = AppwriteSetupAssistant.HasUniTask && AppwriteSetupAssistant.HasWebSocket;
            GUI.enabled = allPackagesInstalled;
            var buttonStyle = new GUIStyle(GUI.skin.button) { padding = new RectOffset(12, 12, 8, 8), margin = new RectOffset(5, 5, 5, 5), fontSize = 12 };
            if (GUILayout.Button("🎮 Setup Current Scene", buttonStyle)) { SetupCurrentScene(); }
            GUI.enabled = true;
            EditorGUILayout.Space(10);
            var headerStyle = new GUIStyle(EditorStyles.boldLabel) { fontSize = 11 };
            EditorGUILayout.LabelField("This will create in the current scene:", headerStyle);
            var itemStyle = new GUIStyle(EditorStyles.label) { richText = true, padding = new RectOffset(15, 0, 2, 2), fontSize = 11 };
            EditorGUILayout.LabelField("• <b>AppwriteManager</b> - Main SDK manager component", itemStyle);
            EditorGUILayout.LabelField("• <b>AppwriteConfig</b> - Configuration asset for your project", itemStyle);
            EditorGUILayout.LabelField("• <b>Realtime</b> - WebSocket connection handler", itemStyle);
            if (!allPackagesInstalled)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.HelpBox("Please install all required packages first", MessageType.Warning);
            }
            EditorGUILayout.EndVertical();
        }
        private void DrawActionButtons()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.BeginHorizontal();
            var buttonStyle = new GUIStyle(GUI.skin.button) { padding = new RectOffset(15, 15, 8, 8), margin = new RectOffset(5, 5, 5, 5), fontSize = 11 };
            if (GUILayout.Button(new GUIContent(" 📖 Documentation", "Open Appwrite documentation"), buttonStyle)) { Application.OpenURL("https://appwrite.io"); }
            if (GUILayout.Button(new GUIContent(" 💬 Discord Community", "Join our Discord community"), buttonStyle)) { Application.OpenURL("https://discord.gg/dJ9xrMr9hq"); }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }
        private void DrawFooter()
        {
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(0, 1), Color.gray);
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Appwrite SDK for Unity", EditorStyles.centeredGreyMiniLabel);
        }
        private async void SetupCurrentScene()
        {
            try
            {
                ShowMessage("Setting up the scene...", MessageType.Info);
                var type = Type.GetType("Appwrite.Utilities.AppwriteUtilities, Appwrite");
                if (type == null) { ShowMessage("AppwriteUtilities not found. Ensure the Runtime assembly is compiled.", MessageType.Warning); return; }
                var method = type.GetMethod("QuickSetup", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                if (method == null) { ShowMessage("QuickSetup method not found in AppwriteUtilities.", MessageType.Warning); return; }
                var task = method.Invoke(null, null);
                if (task == null) { ShowMessage("QuickSetup returned null.", MessageType.Warning); return; }
                dynamic dynamicTask = task;
                var result = await dynamicTask;
                if (result != null)
                {
                    var goProp = result.GetType().GetProperty("gameObject");
                    var go = goProp?.GetValue(result) as GameObject;
                    if (go != null) { Selection.activeGameObject = go; ShowMessage("Scene setup completed successfully!", MessageType.Info); }
                }
            }
            catch (Exception ex) { ShowMessage($"Setup failed: {ex.Message}", MessageType.Error); }
        }
        private void ShowMessage(string message, MessageType type)
        {
            _statusMessage = message;
            _statusMessageType = type;
            Repaint();
            if (type != MessageType.Error)
            {
                EditorApplication.delayCall += () => {
                    if (_statusMessage == message)
                    {
                        System.Threading.Tasks.Task.Delay(5000).ContinueWith(_ => { if (_statusMessage == message) { _statusMessage = ""; Repaint(); } }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                    }
                };
            }
        }
    }
}
