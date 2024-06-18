using System;
using TowerDefense.Scripts.Projectiles;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerAttackHandler : ITickable
    {
        private readonly TowerTargetDetector _targetDetector;
        private readonly TowerProjectile.Pool _pool;
        private readonly Settings _settings;
        private readonly Transform _transform;

        private float _attackTimer;
        private bool CanAttack => _targetDetector.HasTarget && _attackTimer <= 0f;
        
        public TowerAttackHandler(
            TowerTargetDetector targetDetector, 
            TowerProjectile.Pool pool, 
            Settings settings,
            Transform transform)
        {
            _targetDetector = targetDetector;
            _pool = pool;
            _settings = settings;
            _transform = transform;
        }

        public void Tick()
        {
            if (CanAttack)
            {
                SpawnProjectile();
                _attackTimer = _settings.Rate;
            }
            else
            {
                _attackTimer -= Time.deltaTime;
            }
        }

        private void SpawnProjectile()
        {
            var spawnPosition =_transform.position + Vector3.up * _transform.lossyScale.x;
            var projectile = _pool.Spawn(_targetDetector.Target);
            projectile.transform.position = spawnPosition;
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Rate { get; private set; } = 2f;
        }
    }
}