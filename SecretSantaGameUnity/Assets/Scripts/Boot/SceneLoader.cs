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
        public const string MenuSceneName = "Menu";

        public static SceneLoader Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Multiple {name} components should not exist at once");
            }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            StartCoroutine(LoadInitialScenes());
        }

        private IEnumerator<YieldInstruction> LoadInitialScenes()
        {
            var loadMenuScene = SceneManager.LoadSceneAsync(MenuSceneName, LoadSceneMode.Additive);

            while (!(loadMenuScene.isDone))
            {
                yield return null;
            }

            SceneManager.UnloadSceneAsync(BootSceneName);
        }
        private IEnumerator<YieldInstruction> LoadBattle()
        {
            var loadBattleScene = SceneManager.LoadSceneAsync(BattleSceneName, LoadSceneMode.Additive);
            var loadUiScene = SceneManager.LoadSceneAsync(BattleUiSceneName, LoadSceneMode.Additive);

            while (!(loadBattleScene.isDone && loadUiScene.isDone))
            {
                yield return null;
            }

            SceneManager.UnloadSceneAsync(MenuSceneName);
        }

        public void Restart()
        {
            SceneManager.LoadScene(MenuSceneName);
        }

        public void Go()
        {
            StartCoroutine(LoadBattle());
        }

    }
}