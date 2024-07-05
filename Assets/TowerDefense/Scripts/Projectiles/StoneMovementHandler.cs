using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class StoneMovementHandler : IInitializable, IFixedTickable, ITickable
    {
        private readonly Projectile _projectile;
        private readonly Settings _settings;

        private bool _launched;
        private Vector3 _targetPosition;
        
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

        public void Tick()
        {
            DespawnIfReachedTarget();
        }

        private void Launch()
        {
            var startPosition = _projectile.transform.position;
            _targetPosition = _projectile.Target.position;

            var distanceX = Mathf.Abs(_targetPosition.x - startPosition.x);
            var distanceY = _targetPosition.y - startPosition.y;
            
            var gravity = Physics2D.gravity.y;
            var tanAngle = Mathf.Tan(_settings.LaunchAngle * Mathf.Deg2Rad);
            
            var velocityX = Mathf.Sqrt(gravity * distanceX * distanceX / (2f * (distanceY - distanceX * tanAngle)));
            var velocityY = tanAngle * velocityX;
            
            velocityX = _targetPosition.x > startPosition.x ? velocityX : -velocityX;
            
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

        private void DespawnIfReachedTarget()
        {
            var direction = _targetPosition - _projectile.transform.position;

            if (Vector3.SqrMagnitude(direction) < 0.05f) 
                _projectile.Despawn();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float LaunchAngle { get; private set; } = 45f;
        }
    }
}