using System;
using TowerDefense.Scripts.AI.Signals;
using TowerDefense.Scripts.Common;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI
{
    public class EnemyHealthHandler : IInitializable, IDamageable
    {
        private readonly Settings _settings;
        private readonly SignalBus _signalBus;
        public float CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0f;

        public EnemyHealthHandler(Settings settings, SignalBus signalBus)
        {
            _settings = settings;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            CurrentHealth = _settings.MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (!IsAlive)
                return;

            var lastHealth = CurrentHealth;
            CurrentHealth = Mathf.Max(CurrentHealth - damage, 0f);
            
            _signalBus.Fire(new EnemyHealthChangedSignal(lastHealth, CurrentHealth));
        }

        public void Kill()
        {
            TakeDamage(_settings.MaxHealth);
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
        }
    }
}