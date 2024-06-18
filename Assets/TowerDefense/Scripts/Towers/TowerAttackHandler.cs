using System;
using TowerDefense.Scripts.Towers.Projectiles;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerAttackHandler : ITickable
    {
        private readonly TowerTargetDetector _targetDetector;
        private readonly TowerProjectile.Factory _factory;
        private readonly Settings _settings;
        private readonly Transform _transform;

        private float _attackTimer;
        private bool CanAttack => _targetDetector.HasTarget && _attackTimer <= 0f;
        
        public TowerAttackHandler(
            TowerTargetDetector targetDetector, 
            TowerProjectile.Factory factory, 
            Settings settings,
            Transform transform)
        {
            _targetDetector = targetDetector;
            _factory = factory;
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
            var projectile = _factory.Create();
            projectile.transform.position = _transform.position;
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Rate { get; private set; } = 2f;
        }
    }
}