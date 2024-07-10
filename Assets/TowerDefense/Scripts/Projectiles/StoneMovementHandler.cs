using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class StoneMovementHandler : IInitializable, ITickable, IDisposable
    {
        private readonly Projectile _projectile;
        private readonly ProjectilePhysicsHandler _physicsHandler;
        private readonly IProjectileDamageHandler _damageHandler;
        private readonly Settings _settings;

        private Vector3 _targetPosition;
        
        public StoneMovementHandler(
            Projectile projectile, 
            ProjectilePhysicsHandler physicsHandler,
            IProjectileDamageHandler damageHandler,
            Settings settings)
        {
            _projectile = projectile;
            _physicsHandler = physicsHandler;
            _damageHandler = damageHandler;
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
            DespawnIfBeyondMap();
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
            
            var velocity = new Vector2(velocityX, velocityY);
            _physicsHandler.SetVelocity(velocity);
        }

        private void DespawnIfReachedTarget()
        {
            var direction = _targetPosition - _projectile.transform.position;

            if (Vector3.SqrMagnitude(direction) < _settings.MaxDistanceToTarget)
                _projectile.OnHit();
        }

        private void DespawnIfBeyondMap()
        {
            if (_projectile.transform.position.y < _settings.MinYPosition) 
                _projectile.Despawn();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float LaunchAngle { get; private set; } = 45f;
            [field: SerializeField] public float MaxDistanceToTarget { get; private set; } = 0.05f;
            [field: SerializeField] public float MinYPosition { get; private set; } = -10f;
        }
    }
}