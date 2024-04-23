using UnityEngine;

namespace TowerDefense.Scripts.Utils
{
    [ExecuteAlways, RequireComponent(typeof(SpriteRenderer))]
    public class SpriteScaler : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private void Awake()
        {
            Scale();
        }

        private void OnValidate()
        {
            Scale();
        }

        private void Scale()
        {
            if (_renderer == null)
                _renderer = GetComponent<SpriteRenderer>();
            
            var mainCamera = Camera.main!;
            var spriteSize = _renderer.sprite.bounds.size;

            var cameraHeight = mainCamera.orthographicSize * 2f;
            var cameraWidth = cameraHeight * mainCamera.aspect;

            var scale = transform.localScale;
            scale.x = cameraWidth / spriteSize.x;
            scale.y = cameraHeight / spriteSize.y;

            transform.localScale = scale;
        }
    }
}