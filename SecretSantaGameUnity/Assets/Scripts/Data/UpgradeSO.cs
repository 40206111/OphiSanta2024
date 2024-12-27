using UnityEngine;

namespace SecretSanta.Data
{
    [CreateAssetMenu(fileName = "UpgradeData", menuName = "ScriptableObjects/UpgradeData")]
    public class UpgradeSO : ScriptableObject
    {
        public int Uses;
        public string Title;
        public string Body;
    }
}
