using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorOptionUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text prizeText;

        [SerializeField] private Sprite disabledIcon;
        
        private Action _onClick;

        private void OnEnable()
        {
            button.onClick.AddListener(Button_OnClick);
        }

        private void OnDisable()
        {
            Clear();
            button.onClick.RemoveListener(Button_OnClick);
        }

        private void Clear()
        {
            _onClick = null;
            prizeText.text = "";
        }

        private void Button_OnClick() 
        {
            _onClick?.Invoke();
        }

        public void SetupDisabled()
        {
            image.sprite = disabledIcon;
            prizeText.text = "";

            button.interactable = false;
        }
        public void SetupEnabled(Action onClick)
        {
            _onClick = onClick;
            ToggleButtonAsync().Forget();
        }

        public void SetupEnabled(Action onClick, Sprite sprite)
        {
            image.sprite = sprite;
            SetupEnabled(onClick);
        }
        
        public void SetupEnabled(Action onClick, string text)
        {
            prizeText.text = text;
            SetupEnabled(onClick);
        }

        public void SetupEnabled(Action onClick, Sprite sprite, string text)
        {
            image.sprite = sprite;
            SetupEnabled(onClick, text);
        }

        private async UniTaskVoid ToggleButtonAsync()
        {
            button.interactable = false;
            await UniTask.Delay(200);
            button.interactable = true;
        }
    }
}