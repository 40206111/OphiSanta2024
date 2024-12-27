using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSant.Upgrade
{
    [CreateAssetMenu(fileName = "UpgradeData", menuName = "ScriptableObjects/UpgradeData")]
    public class UpgradeSO : ScriptableObject
    {
        public string Title;
        public string Body;
    }
}
