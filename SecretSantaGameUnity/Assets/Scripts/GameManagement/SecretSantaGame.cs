using SecretSanta.Boot;
using SecretSanta.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.GameManagment
{
    public class SecretSantaGame : MonoBehaviour
    {
        public static SecretSantaGame Instance;
        public PlayerData CurPlayerData;

        private PlayerControls mainControls;

        private bool GameOvered = false;
        private bool GameStarted = false;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Multiple {name} components should not exist at once");
            }

            Instance = this;

            CurPlayerData = new PlayerData();
            CurPlayerData.SetDefultData();
            mainControls = new PlayerControls();
        }

        private void Update()
        {
            if (GameOvered)
            {
                if (mainControls.GameNavigation.Restart.triggered)
                {
                    SceneLoader.Instance.Restart();
                    GameOvered = false;
                    GameStarted = false;
                }
                return;
            }

            if (!GameStarted)
            {
                if (mainControls.GameNavigation.Restart.triggered)
                {
                    Debug.Log("Start Game");
                    SceneLoader.Instance.Restart();
                    GameStarted = true;
                }
            }
        }
        public void GameOver()
        {
            GameOvered = true;
            mainControls.Enable();
            Time.timeScale = 0;
        }

    }
}