using System;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorUI : MonoBehaviour
    {
        [BoxGroup("Towers")][SerializeField] private Tower[] towers;
        
        [BoxGroup("Options")][SerializeField] private TowerSelectorOptionUI[] basicOptions;
        [BoxGroup("Options")][SerializeField] private TowerSelectorOptionUI[] advancedOptions;

        private TowerField _towerField;
        private Image _image;
        private RectTransform RectTransform => transform as RectTransform;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            Hide();
        }

        public void Show(TowerField towerField)
        {
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
            _image.enabled = true;
        }

        private void SetupBasicOptions()
        {
            for (var i = 0; i < basicOptions.Length; i++)
            {
                var option = basicOptions[i];
                var tower = towers[i];
                
                option.Setup(tower.Icon, () => _towerField.BuildTower(tower));
            }
        }

        private void SetupAdvancedOptions()
        {
            
        }

        public void Hide()
        {
            _image.enabled = false;
            _towerField = null;
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