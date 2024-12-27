using SecretSanta.Data;
using SecretSanta.Upgrades;
using SecretSanta.GameManagment;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SecretSanta.UI
{
    public class UiUpgradeController : MonoBehaviour
    {
        [SerializeField] List<UpgradeSO> Upgrades;
        [SerializeField] List<UpgradeSO> BackUpUpgrades;
        [SerializeField] Upgrade UpgradePrefab;
        [SerializeField] int _upgradesToShow;

        List<Upgrade> _upgradePool = new List<Upgrade>();
        List<UpgradeData> _upgradeDataPool = new List<UpgradeData>();
        List<UpgradeData> _backUpUpgradeData = new List<UpgradeData>();
        List<UpgradeData> _usedUpgrades = new List<UpgradeData>();

        bool OpenedUpgrades;

        private void Awake()
        {
            for (int i = 0; i < _upgradesToShow; ++i)
            {
                var upgradeCard = Instantiate(UpgradePrefab, transform);
                upgradeCard.gameObject.SetActive(false);
                var butt = upgradeCard.GetComponent<Button>();
                if (i == 0)
                {
                    butt.Select();
                }
                butt.onClick.AddListener(CloseUpgrades);
                _upgradePool.Add(upgradeCard);
            }

            foreach (var upgrade in Upgrades)
            {
                var upgradeData = new UpgradeData(upgrade);
                _upgradeDataPool.Add(upgradeData);
            }

            foreach (var upgrade in BackUpUpgrades)
            {
                var upgradeData = new UpgradeData(upgrade);
                _backUpUpgradeData.Add(upgradeData);
            }
        }

        private void Update()
        {
            if (!OpenedUpgrades && SecretSantaGame.Instance.UpgradeTime)
            {
                OpenedUpgrades = true;
                OpenUpgrades();
            }
        }

        void OpenUpgrades()
        {
            foreach ( var upgrade in _upgradePool )
            {
                upgrade.gameObject.SetActive(true);
                if (_upgradeDataPool.Count == 0)
                {
                    var id = Random.Range(0, _backUpUpgradeData.Count);
                    var backUpData = _upgradeDataPool[id];
                    upgrade.SetUp(backUpData);
                    _usedUpgrades.Add(backUpData);
                    continue;
                }
                var index = Random.Range(0, _upgradeDataPool.Count);
                var data = _upgradeDataPool[index];
                upgrade.SetUp(data);
                _usedUpgrades.Add(data);
                _upgradeDataPool.RemoveAt(index);
            }
        }

        void CloseUpgrades()
        {
            for (int i = 0; i < _upgradePool.Count; ++i)
            {
                _upgradePool[i].gameObject.SetActive(false);
                _usedUpgrades[i] = _upgradePool[i].Data;
                if (_usedUpgrades[i].Uses != 0)
                {
                    _upgradeDataPool.Add(_usedUpgrades[i]);
                }
            }

            _usedUpgrades.Clear();

            SecretSantaGame.Instance.ResumeFromUpgrade();
            OpenedUpgrades = false;
        }

    }
}