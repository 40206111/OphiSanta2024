using SecretSanta.GameManagment;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UiHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private void OnEnable()
    {
        var highScore = PlayerPrefs.GetInt("Score", 0);
        _text.enabled = highScore > 0;
        _text.text = $"High Score: {highScore}";
    }
}
