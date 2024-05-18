using System;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace TowerDefense.Utils
{
    [ExecuteAlways]
    public class ScreenResolutionListener : MonoBehaviour
    {
        private int _width;
        private int _height;

        public event Action<ScreenResolutionChangedEventArgs> ResolutionChanged;
        
        private void Awake()
        {
            _width = Screen.width;
            _height = Screen.height;
        }
        
        private void Update()
        {
            if (_width == Screen.width && _height == Screen.height) 
                return;

            OnResolutionChanged();
        }

        private void OnResolutionChanged()
        {
            _width = Screen.width;
            _height = Screen.height;

            ResolutionChanged?.Invoke(new ScreenResolutionChangedEventArgs(_width, _height));
        }
    }
}