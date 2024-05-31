using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorUI : MonoBehaviour
    {
        [SerializeField] private Tower[] towers;

        [SerializeField] private TowerSelectorOptionUI[] basicOptions;
        [SerializeField] private TowerSelectorOptionUI upgradeOption;
        [SerializeField] private TowerSelectorOptionUI sellOption;

        [SerializeField] private GameObject basicOptionsContainer;
        [SerializeField] private GameObject advancedOptionsContainer;

        [SerializeField] private Sprite upgradeSprite;
        [SerializeField] private Sprite sellSprite;
        
        [SerializeField] private CanvasGroup canvasGroup;

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
            _image.enabled = true;
            basicOptionsContainer.SetActive(true);
            advancedOptionsContainer.SetActive(false);
            
            for (var i = 0; i < basicOptions.Length; i++)
            {
                var option = basicOptions[i];
                var tower = towers[i];

                option.Setup(tower.Icon, () =>
                {
                    _towerField.BuildTower(tower);
                    Hide();
                });
            }
        }

        private void SetupAdvancedOptions()
        {
            _image.enabled = false;
            basicOptionsContainer.SetActive(false);
            advancedOptionsContainer.SetActive(true);

            upgradeOption.Setup(upgradeSprite, () => _towerField.UpgradeTower());
            sellOption.Setup(sellSprite, () => _towerField.SellTower());
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