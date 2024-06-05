using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorUI : MonoBehaviour
    {
        [SerializeField] private TowerData[] towers;

        [SerializeField] private TowerSelectorOptionUI[] basicOptions;
        [SerializeField] private TowerSelectorOptionUI upgradeOption;
        [SerializeField] private TowerSelectorOptionUI sellOption;

        [SerializeField] private GameObject basicOptionsContainer;
        [SerializeField] private GameObject advancedOptionsContainer;

        [SerializeField] private Image image;
        
        private TowerField _towerField;
        private RectTransform RectTransform => transform as RectTransform;
        
        public void Show(TowerField towerField)
        {
            gameObject.SetActive(true);
            _towerField = towerField;

            if (towerField.IsEmpty)
            {
                SetupBasicOptions();
            }
            else
            {
                SetupAdvancedOptions();
            }

            SetPositionOnTowerCenter(towerField);
        }

        public void Hide()
        {
            _towerField = null;
            gameObject.SetActive(false);
        }

        private void SetupBasicOptions()
        {
            ShowBasicOptions(true);
            
            for (var i = 0; i < basicOptions.Length; i++)
            {
                var option = basicOptions[i];
                var tower = towers[i];
                
                option.Setup(() =>
                {
                    _towerField.BuildTower(tower);
                    Hide();
                }, tower.Icon);
            }
        }

        private void SetupAdvancedOptions()
        {
            ShowBasicOptions(false);

            var isUpgradeAvailable = _towerField.CurrentTowerData.CanUpgrade;
            upgradeOption.gameObject.SetActive(isUpgradeAvailable);
            upgradeOption.Setup(() =>
            {
                _towerField.UpgradeTower();
                Hide();
            });
            
            sellOption.Setup(() =>
            {
                _towerField.SellTower();
                Hide();
            });
        }

        private void ShowBasicOptions(bool basic)
        {
            image.enabled = basic;
            basicOptionsContainer.SetActive(basic);
            advancedOptionsContainer.SetActive(!basic);
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