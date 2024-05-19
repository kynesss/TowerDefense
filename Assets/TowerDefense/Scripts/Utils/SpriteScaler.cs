using UnityEngine;

namespace TowerDefense.Scripts.Utils
{
    [ExecuteAlways, RequireComponent(typeof(SpriteRenderer))]
    public class SpriteScaler : MonoBehaviour
    {
        [SerializeField] 
        private bool includeSafeArea;

        [SerializeField] // TODO: inject this with Zenject AsSingle
        private ScreenResolutionListener screenResolutionListener;
        
        private SpriteRenderer _renderer;

        private void Awake()
        {
            Scale();
        }

        private void OnEnable()
        {
            screenResolutionListener.ResolutionChanged += ScreenResolutionListener_OnResolutionChanged;
        }

        private void OnDisable()
        {
            screenResolutionListener.ResolutionChanged -= ScreenResolutionListener_OnResolutionChanged;
        }

        private void Scale()
        {
            if (_renderer == null)
                _renderer = GetComponent<SpriteRenderer>();

            var mainCamera = Camera.main!;
            var spriteSize = _renderer.sprite.bounds.size;

            var cameraHeight = mainCamera.orthographicSize * 2f;
            var cameraWidth = cameraHeight * mainCamera.aspect;

            if (includeSafeArea)
            {
                var safeArea = Screen.safeArea;
                cameraWidth *= safeArea.width / Screen.width;
                cameraHeight *= safeArea.height / Screen.height;

                Vector2 safeAreaCenter = mainCamera.ScreenToWorldPoint(safeArea.center);
                transform.position = safeAreaCenter;
            }

            transform.localScale = new Vector3(cameraWidth / spriteSize.x, cameraHeight / spriteSize.y);
        }

        private void ScreenResolutionListener_OnResolutionChanged(ScreenResolutionChangedEventArgs args)
        {
            Scale();
        }
    }
}