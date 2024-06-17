﻿using System;
using System.Collections.Generic;
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
            ShowBasicOptions(true);
            
            for (var i = 0; i < basicOptions.Length; i++)
            {
                var option = basicOptions[i];
                var tower = basicTowers[i];
                
                option.Setup(() =>
                {
                    SetupAdvancedBuildOptions(tower);
                }, tower.Icon);
            }
        }

        private void SetupAdvancedBuildOptions(TowerData towerType)
        {
            ShowBasicOptions(true);
            
            for (var i = 0; i < basicOptions.Length; i++)
            {
                var option = basicOptions[i];
                var tower = towersByType[towerType][i];
                
                option.Setup(() =>
                {
                    _towerField.BuildTower(tower);
                    Hide();
                }, tower.Icon);
            }
        }

        private void SetupUpgradeOptions()
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