using SecretSanta.Boot;
using SecretSanta.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            mainControls.GameNavigation.Restart.performed += RestartPressed;
            mainControls.Enable();
        }

        void RestartPressed(InputAction.CallbackContext cbc)
        {
            if (GameOvered)
            {
                SceneLoader.Instance.Restart();
            }
            if (!GameStarted)
            {
                SceneLoader.Instance.Go();
                GameStarted = true;
            }
        }

        private IEnumerator<YieldInstruction> WaitToGoAgain()
        {
            yield return new WaitForSeconds(0.5f);
            GameOvered = false;
            GameStarted = false;
        }

        public void GameOver()
        {
            GameOvered = true;
            Time.timeScale = 0;
        }

    }
}