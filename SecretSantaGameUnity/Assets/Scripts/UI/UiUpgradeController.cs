using SecretSant.Upgrade;
using SecretSanta.GameManagment;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.UI
{
    public class UiUpgradeController : MonoBehaviour
    {
        [SerializeField] List<UpgradeSO> Upgrades;
        [SerializeField] Upgrade UpgradePrefab;
        [SerializeField] int _upgradesToShow;

        List<Upgrade> _upgradePool = new List<Upgrade>();

        bool OpenedUpgrades;

        private void Awake()
        {
            for (int i = 0; i < _upgradesToShow; ++i)
            {
                var upgradeCard = Instantiate(UpgradePrefab, transform);
                upgradeCard.gameObject.SetActive(false);
                _upgradePool.Add(upgradeCard);
            }
        }

        private void Update()
        {
            if (SecretSantaGame.Instance.UpgradeTime)
            {
                OpenUpgrades();
            }
        }

        void OpenUpgrades()
        {
            foreach ( var upgrade in _upgradePool )
            {
                upgrade.gameObject.SetActive(true);
            }
        }

        void CloseUpgrades()
        {
            foreach (var upgrade in _upgradePool)
            {
                upgrade.gameObject.SetActive(false);
            }

        }
    }
}