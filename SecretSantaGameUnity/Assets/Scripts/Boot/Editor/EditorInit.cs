#if UNITY_EDITOR
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
            var pathOfFirstScene = SceneLoader.ScenePath + SceneLoader.BootSceneName + SceneLoader.SceneExtension;
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);
            if (sceneAsset == null)
            {
                Debug.LogError($"Failed to load boot scene {pathOfFirstScene}");
                return;
            }
            EditorSceneManager.playModeStartScene = sceneAsset;
            Debug.Log($"{pathOfFirstScene} was set as default play mode scene");
        }
    }
}
#endif