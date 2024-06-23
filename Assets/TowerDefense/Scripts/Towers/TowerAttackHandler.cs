using System;
using EasyButtons;
using TowerDefense.Scripts.Projectiles;
using TowerDefense.Scripts.Towers.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerAttackHandler : IInitializable, ITickable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly Projectile.Pool _pool;
        private readonly Settings _settings;
        private readonly Transform _transform;

        private Transform _target;
        private float _attackTimer;
        private bool CanAttack => _target != null && _attackTimer <= 0f;

        public TowerAttackHandler(
            SignalBus signalBus,
            Projectile.Pool pool,
            Settings settings,
            Transform transform)
        {
            _signalBus = signalBus;
            _pool = pool;
            _settings = settings;
            _transform = transform;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<TowerTargetChangedSignal>(OnTowerTargetChanged);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<TowerTargetChangedSignal>(OnTowerTargetChanged);
        }

        private void OnTowerTargetChanged(TowerTargetChangedSignal signal)
        {
            if (signal.Target != null)
            {
                _attackTimer = _settings.Rate;
                _target = signal.Target!.transform;
            }
            else
            {
                _target = null;
            }
        }

        public void Tick()
        {
            if (CanAttack)
            {
                SpawnProjectile();
            }
            else
            {
                _attackTimer -= Time.deltaTime;
            }
        }
        
        private void SpawnProjectile()
        {
            var spawnPosition = _transform.position + _settings.SpawnOffset;
            var projectile = _pool.Spawn(_target);
            projectile.SetPosition(spawnPosition);

            _attackTimer = _settings.Rate;
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Rate { get; private set; } = 2f;
            [field: SerializeField] public Vector3 SpawnOffset { get; private set; }
        }
    }
}