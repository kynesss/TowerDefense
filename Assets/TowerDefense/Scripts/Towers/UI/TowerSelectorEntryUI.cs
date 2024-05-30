using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorEntryUI : MonoBehaviour
    {
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
            SetPositionOnTowerCenter(towerField);
            _image.enabled = true;
        }

        public void Hide()
        {
            _image.enabled = false;
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