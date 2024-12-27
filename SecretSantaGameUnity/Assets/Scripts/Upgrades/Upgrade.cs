using SecretSanta.Data;
using TMPro;
using UnityEngine;

namespace SecretSanta.Upgrades
{
    public class Upgrade : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI Title;
        [SerializeField] TextMeshProUGUI Body;
        public UpgradeData Data;

        public void SetUp(UpgradeData data)
        {
            Title.text = data.Title;
            Body.text = data.Body;
            Data = data;
        }

        public void Selected()
        {
            if (Data.Uses >= 0)
            {
                Data.Uses--;
            }
        }
    }
}