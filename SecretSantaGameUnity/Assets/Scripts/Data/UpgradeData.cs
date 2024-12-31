using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Data
{
    public class UpgradeData
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
        public int AddSwordDamage;

        public UpgradeData(UpgradeSO data)
        {
            Title = data.Title;
            Body = data.Body;
            Uses = data.Uses;
            AddHealth = data.AddHealth;
            AddSpeed = data.AddSpeed;
            AddSwordSpeed = data.AddSwordSpeed;
            AddSwordSize = data.AddSwordSize;
            AddCollectRadius = data.AddCollectRadius;
            DecSwordCooldown = data.DecSwordCooldown;
            AddSwordDamage = data.AddSwordDamage;
    }
    }
}