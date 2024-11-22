using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class EditorInit
{
    static EditorInit()
    {
        // might want to change this to be specifically the boot scene so we can have a splash
        // screen scene that is skipped in editor
        var pathOfFirstScene = EditorBuildSettings.scenes[1].path;
        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);
        EditorSceneManager.playModeStartScene = sceneAsset;
        Debug.Log(pathOfFirstScene + " was set as default play mode scene");
    }
}
