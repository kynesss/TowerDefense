using System;
using System.Collections.Generic;
using System.Globalization;
using AYellowpaper.SerializedCollections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorUI : MonoBehaviour
    {
        [SerializeField] private TowerData[] basicTowers;
        [SerializeField] private SerializedDictionary<TowerData, List<TowerData>> towersByType;

        [SerializeField] private TowerSelectorOptionUI[] buildOptions;
        [SerializeField] private TowerSelectorOptionUI upgradeOption;
        [SerializeField] private TowerSelectorOptionUI sellOption;

        [SerializeField] private GameObject buildOptionsContainer;
        [SerializeField] private GameObject upgradeOptionsContainer;

        [SerializeField] private Image image;

        private TowerField _towerField;
        private RectTransform RectTransform => transform as RectTransform;

        public void Show(TowerField towerField)
        {
            gameObject.SetActive(true);
            _towerField = towerField;

            if (towerField.IsEmpty)
            {
                SetupBasicBuildOptions();
            }
            else
            {
                SetupUpgradeOptions();
            }

            SetPositionOnTowerCenter(towerField);
        }

        public void Hide()
        {
            _towerField = null;
            gameObject.SetActive(false);
        }

        private void SetupBasicBuildOptions()
        {
            ShowBuildOptions(true);

            for (var i = 0; i < buildOptions.Length; i++)
            {
                var option = buildOptions[i];
                var tower = basicTowers[i];

                option.SetupEnabled(() => { SetupAdvancedBuildOptions(tower); }, tower.Icon);
            }
        }

        private void SetupAdvancedBuildOptions(TowerData towerType)
        {
            ShowBuildOptions(true);

            for (var i = 0; i < buildOptions.Length; i++)
            {
                var option = buildOptions[i];
                var tower = towersByType[towerType][i];

                Debug.Log($"IsUnlocked: {tower.IsUnlocked()}");
                
                if (tower.IsUnlocked())
                {
                    option.SetupEnabled(() =>
                        {
                            _towerField.BuildTower(tower);
                            Hide();
                        }, tower.Icon,
                        tower.Prize.ToString());
                }
                else
                {
                    option.SetupDisabled();
                }
            }
        }

        private void SetupUpgradeOptions()
        {
            ShowBuildOptions(false);

            var towerData = _towerField.CurrentTowerData;
            var isUpgradeAvailable = towerData.CanUpgrade;
            var sellPrice = towerData.Prize / 2;

            if (isUpgradeAvailable)
            {
                var upgradePrice = towerData.Upgrade.Prize;

                upgradeOption.gameObject.SetActive(true);
                upgradeOption.SetupEnabled(() =>
                {
                    _towerField.UpgradeTower();
                    Hide();
                }, upgradePrice.ToString());
            }
            else
            {
                upgradeOption.gameObject.SetActive(false);
            }

            sellOption.SetupEnabled(() =>
            {
                _towerField.SellTower();
                Hide();
            }, sellPrice.ToString());
        }

        private void ShowBuildOptions(bool basic)
        {
            image.enabled = basic;
            buildOptionsContainer.SetActive(basic);
            upgradeOptionsContainer.SetActive(!basic);
        }

        private void SetPositionOnTowerCenter([NotNull] TowerField towerField)
        {
            if (towerField == null)
                throw new ArgumentNullException(nameof(towerField));

            var towerWorldPos = towerField.transform.position;
            var towerScreenPos = Camera.main!.WorldToScreenPoint(towerWorldPos);
            var parentRect = transform.parent as RectTransform;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, towerScreenPos, null,
                out var localPoint);

            RectTransform.anchoredPosition = localPoint;
        }
    }
}