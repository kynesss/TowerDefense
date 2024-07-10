using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class StoneMovementHandler : IInitializable, ITickable, IDisposable
    {
        private readonly Projectile _projectile;
        private readonly Settings _settings;

        private Vector3 _targetPosition;
        
        public StoneMovementHandler(
            Projectile projectile, Settings settings)
        {
            _projectile = projectile;
            _settings = settings;
        }

        public void Initialize()
        {
            _projectile.TargetChanged += Projectile_OnTargetChanged;
        }

        public void Dispose()
        {
            _projectile.TargetChanged -= Projectile_OnTargetChanged;
        }

        private void Projectile_OnTargetChanged(Transform target)
        {
            if (target != null)
            {
                Launch(target.position);
            }
        }

        public void Tick()
        {
            DespawnIfReachedTarget();
        }

        private void Launch(Vector3 targetPosition)
        {
            var startPosition = _projectile.transform.position;
            _targetPosition = targetPosition;

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
                _projectile.OnHit();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float LaunchAngle { get; private set; } = 45f;
        }
    }
}