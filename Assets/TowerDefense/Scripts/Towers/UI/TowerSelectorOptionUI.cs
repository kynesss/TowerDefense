using System;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorOptionUI : MonoBehaviour
    {
        private Image _icon;
        private Button _button;
        private Action _action;
        
        private void Awake()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Button_OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Button_OnClick);
        }

        private void Button_OnClick()
        {
            _action?.Invoke();
        }

        public void Setup(Sprite sprite, Action action)
        {
            //_icon.sprite = sprite;
            _action = action;
        }
    }
}