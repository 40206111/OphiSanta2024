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

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Multiple {name} components should not exist at once");
            }

            Instance = this;

            CurPlayerData = new PlayerData();
            CurPlayerData.SetDefultData();
        }

    }
}