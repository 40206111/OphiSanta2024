using System.Collections;
using System.Collections.Generic;
using SecretSanta.GameManagment;
using UnityEngine;

namespace SecretSanta.UI
{
    public class UiGameOver : MonoBehaviour
    {
        [SerializeField] GameObject GameOverObject;

        private void Update()
        {
            GameOverObject.SetActive(SecretSantaGame.Instance.GameOvered);
        }
    }
}