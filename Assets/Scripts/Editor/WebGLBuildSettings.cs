using System.IO;
using UnityEngine;
using UnityEditor;

//[CreateAssetMenu(fileName = "WebGLBuildSettings", menuName = "Build Settings/WebGLBuildSettings")]
public class WebGLBuildSettings : ScriptableObject
{
    private const string kBuildSettingsDirectory = "Assets/Settings/BuildSettings/";
    private const string kSettingsAssetName = "WebGLBuildSettings.asset";
    public bool runPostProcessScript = true;

    [MenuItem("Tools/WebGL Build Settings")]
    public static void ShowSettings()
    {
        WebGLBuildSettings settings =
            AssetDatabase.LoadAssetAtPath<WebGLBuildSettings>(kBuildSettingsDirectory + kSettingsAssetName);
        if (settings == null)
        {
            // Create Directory
            if (!Directory.Exists(kBuildSettingsDirectory))
            {
                Directory.CreateDirectory(kBuildSettingsDirectory);
            }

            settings = CreateInstance<WebGLBuildSettings>();
            AssetDatabase.CreateAsset(settings, kBuildSettingsDirectory + kSettingsAssetName);
            AssetDatabase.SaveAssets();
        }

        Selection.activeObject = settings;
    }
}