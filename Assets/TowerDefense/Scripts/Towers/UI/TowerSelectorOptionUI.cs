using System;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorOptionUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button
            ;
        private Action _onClick;

        private void OnEnable()
        {
            button.onClick.AddListener(Button_OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Button_OnClick);
        }

        private void Button_OnClick()
        {
            _onClick?.Invoke();
        }

        public void Setup(Sprite sprite, Action onClick)
        {
            icon.sprite = sprite;
            _onClick = onClick;
        }
    }
}