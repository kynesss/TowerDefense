using System;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorUI : MonoBehaviour
    {
        [BoxGroup("Towers")] [SerializeField] private Tower[] towers;

        [BoxGroup("Options")] [SerializeField] private TowerSelectorOptionUI[] basicOptions;
        [BoxGroup("Options")] [SerializeField] private TowerSelectorOptionUI[] advancedOptions;

        [SerializeField] private CanvasGroup canvasGroup;

        private TowerField _towerField;
        private RectTransform RectTransform => transform as RectTransform;

        private void Start()
        {
            Hide();
        }

        public void Setup(TowerField towerField)
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
            Show();
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

        [EasyButtons.Button("Show")]
        public void Show()
        {
            canvasGroup.alpha = 1f;
        }

        [EasyButtons.Button("Hide")]
        public void Hide()
        {
            canvasGroup.alpha = 0f;
        }
    }
}