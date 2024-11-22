using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SecretSanta.Boot.Editor
{
    [InitializeOnLoad]
    public class EditorInit
    {
        static EditorInit()
        {
            var pathOfFirstScene = SceneLoader.DefaultScenePath;
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);
            EditorSceneManager.playModeStartScene = sceneAsset;
            Debug.Log(pathOfFirstScene + " was set as default play mode scene");
        }
    }
}