using SecretSanta.GameManagment;
using TMPro;
using UnityEngine;

public class UiScoreShower : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private void OnEnable()
    {
        var level = SecretSantaGame.Instance.CurPlayerData.Level;
        var highScore = PlayerPrefs.GetInt("Score", 0);
        if (level > highScore)
        {
            PlayerPrefs.SetInt("Score", level);
            _text.text = $"You got {level} upgrades *HIGH SCORE*";
        }
        else
        {
            _text.text = $"You got {level} upgrades";
        }
    }
}
