#if UNITY_WEBGL
using UnityEngine;
using UnityEditor;
using System.IO;
using System.IO.Compression;
using UnityEditor.Callbacks;


public abstract class WebGLBuildPostProcessor
{
    private const string kBuildSettingsDirectory = "Assets/Settings/BuildSettings/";
    private const string kSettingsAssetName = "WebGLBuildSettings.asset";

    [PostProcessBuild(1)]
    public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        // Check Command-Line arg
        // string[] args = Environment.GetCommandLineArgs();
        // bool runPostProcess = false;
        // foreach (string arg in args)
        // {
        //     if (arg == "-runBuildPostProcess")
        //     {
        //         runPostProcess = true;
        //         break;
        //     }
        // }
        //
        // if (!runPostProcess)
        //     return;

        WebGLBuildSettings settings =
            AssetDatabase.LoadAssetAtPath<WebGLBuildSettings>(kBuildSettingsDirectory + kSettingsAssetName);
        if (settings == null && !settings.runPostProcessScript)
            return;

        Debug.Log("Post-build script executed!");
        Debug.Log("Built project path: " + pathToBuiltProject);

        // Example: Perform actions based on the build target
        if (target == BuildTarget.WebGL)
        {
            ZipBuild(pathToBuiltProject);
        }
    }

    private static void ZipBuild(string buildPath)
    {
        // Zip the entire exported build directory
        string zipPath = buildPath + ".zip";
        if (File.Exists(zipPath))
        {
            File.Delete(zipPath);
        }

        ZipFile.CreateFromDirectory(buildPath, zipPath);
        Debug.Log($"Build artifact zipped to: {zipPath}");
    }
}
#endif