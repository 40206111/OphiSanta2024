using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SecretSanta.Boot
{
    public class SceneLoader : MonoBehaviour
    {
        public const string ScenePath = "Assets/Scenes/";
        public const string SceneExtension = ".unity";
        public const string BootSceneName = "BootScene";
        public const string BattleSceneName = "BattleScene";
        public const string BattleUiSceneName = "BattleUIScene";

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            StartCoroutine(LoadInitialScenes());
        }

        private IEnumerator<YieldInstruction> LoadInitialScenes()
        {
            var loadBattleScene = SceneManager.LoadSceneAsync(BattleSceneName, LoadSceneMode.Additive);
            var loadUiScene = SceneManager.LoadSceneAsync(BattleUiSceneName, LoadSceneMode.Additive);

            while (!(loadBattleScene.isDone && loadUiScene.isDone))
            {
                yield return null;
            }

            SceneManager.UnloadSceneAsync(BootSceneName);
        }

    }
}