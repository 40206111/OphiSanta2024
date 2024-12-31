using SecretSanta.Boot;
using SecretSanta.Data;
using System;
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
        public Action<UpgradeData> UpgradeAdded;

        private PlayerControls mainControls;

        public bool GameOvered = false;
        private bool GameStarted = false;
        public bool UpgradeTime = false;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Multiple {name} components should not exist at once");
            }

            Instance = this;
            mainControls = new PlayerControls();
            mainControls.GameNavigation.Restart.performed += RestartPressed;
            mainControls.Enable();

            Reset();
        }

        private void Update()
        {
            if (CurPlayerData.Experience >= CurPlayerData.XpToNextLvl)
            {
                Time.timeScale = 0;
                UpgradeTime = true;
                CurPlayerData.Experience -= CurPlayerData.XpToNextLvl;
                CurPlayerData.Level++;
                CurPlayerData.XpToNextLvl += 2;
            }
        }

        private void Reset()
        {
            CurPlayerData = new PlayerData();
            CurPlayerData.SetDefultData();
        }

        void RestartPressed(InputAction.CallbackContext cbc)
        {
            if (GameOvered && GameStarted)
            {
                SceneLoader.Instance.Restart();
                Time.timeScale = 1;
                StartCoroutine(WaitToGoAgain());
            }
            if (!GameStarted)
            {
                Reset();
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

        public void ResumeFromUpgrade()
        {
            UpgradeTime = false;
            Time.timeScale = 1;
        }

        public void AddUpgrade(UpgradeData upgrade)
        {
            UpgradeAdded?.Invoke(upgrade);
        }

    }
}