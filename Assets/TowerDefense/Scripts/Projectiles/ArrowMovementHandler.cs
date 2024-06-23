using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class ArrowMovementHandler : ITickable
    {
        private readonly Projectile _projectile;
        private readonly Settings _settings;
        public ArrowMovementHandler(Projectile projectile, Settings settings)
        {
            _projectile = projectile;
            _settings = settings;
        }

        public void Tick()
        {
            var direction = _projectile.Target.position - _projectile.transform.position; 
            
            if (Vector3.SqrMagnitude(direction) < 0.05f)
            {
                _projectile.Despawn();
                return;
            }
            
            direction.Normalize();
            
            MoveTowards(direction);   
            RotateTowards(direction);
        }

        private void MoveTowards(Vector3 direction)
        {
            _projectile.transform.position += direction * (_settings.Speed * Time.deltaTime);
        }

        private void RotateTowards(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Speed { get; private set; } = 10f;
        }
    }
}