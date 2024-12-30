using UnityEngine;

namespace SecretSanta.Data
{
    [CreateAssetMenu(fileName = "UpgradeData", menuName = "ScriptableObjects/UpgradeData")]
    public class UpgradeSO : ScriptableObject
    {
        public int Uses;
        public string Title;
        public string Body;

        public int AddHealth;
        public float AddSpeed;
        public float AddSwordSpeed;
        public float AddSwordSize;
        public float AddCollectRadius;
        public float DecSwordCooldown;

    }
}
