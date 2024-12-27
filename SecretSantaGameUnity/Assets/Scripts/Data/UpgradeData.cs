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

        public UpgradeData(UpgradeSO data)
        {
            Title = data.Title;
            Body = data.Body;
            Uses = data.Uses;
        }
    }
}