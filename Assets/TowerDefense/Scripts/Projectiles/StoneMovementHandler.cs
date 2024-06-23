using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class StoneMovementHandler : IInitializable, IFixedTickable
    {
        private readonly Projectile _projectile;
        private readonly Settings _settings;

        private bool _launched;
        
        public StoneMovementHandler(Projectile projectile, Settings settings)
        {
            _projectile = projectile;
            _settings = settings;
        }

        public void Initialize()
        {
            _launched = false;
        }

        public void FixedTick()
        {
            if (_launched == false)
            {
                Launch();
                _launched = true;
            }
        }

        private void Launch()
        {
            var startPosition = _projectile.transform.position;
            var targetPosition = _projectile.Target.position;

            var distanceX = Mathf.Abs(targetPosition.x - startPosition.x);
            var distanceY = targetPosition.y - startPosition.y;
            
            var gravity = Physics2D.gravity.y;
            var tanAngle = Mathf.Tan(_settings.LaunchAngle * Mathf.Deg2Rad);
            
            var velocityX = Mathf.Sqrt(gravity * distanceX * distanceX / (2f * (distanceY - distanceX * tanAngle)));
            var velocityY = tanAngle * velocityX;
            
            velocityX = targetPosition.x > startPosition.x ? velocityX : -velocityX;


            if (float.IsNaN(velocityX))
            {
                Debug.LogError($"VelX {velocityX} is Nan!");
                return;
            }
            
            if (float.IsNaN(velocityY))
            {
                Debug.LogError($"VelY {velocityY} is Nan!");
                return;
            }
            
            _projectile.Rigidbody.velocity = new Vector2(velocityX, velocityY);
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float LaunchAngle { get; private set; } = 45f;
        }
    }
}