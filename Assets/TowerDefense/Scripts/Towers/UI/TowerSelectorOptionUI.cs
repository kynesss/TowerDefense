using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorOptionUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text prizeText;
        
        private Action _onClick;

        private void OnEnable()
        {
            button.onClick.AddListener(Button_OnClick);
        }

        private void OnDisable()
        {
            _onClick = null;
            button.onClick.RemoveListener(Button_OnClick);
        }

        private void Button_OnClick() 
        {
            _onClick?.Invoke();
        }

        public void Setup(Action onClick)
        {
            _onClick = onClick;
            ToggleButtonAsync().Forget();
        }

        public void Setup(Action onClick, Sprite sprite)
        {
            icon.sprite = sprite;
            Setup(onClick);
        }
        
        public void Setup(Action onClick, string text)
        {
            prizeText.text = text;
            Setup(onClick);
        }

        public void Setup(Action onClick, Sprite sprite, string text)
        {
            icon.sprite = sprite;
            Setup(onClick, text);
        }

        private async UniTaskVoid ToggleButtonAsync()
        {
            button.interactable = false;
            await UniTask.Delay(200);
            button.interactable = true;
        }
    }
}