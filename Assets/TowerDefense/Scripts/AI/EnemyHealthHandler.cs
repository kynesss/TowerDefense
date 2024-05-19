using System;
using TowerDefense.Scripts.Common;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI
{
    public class EnemyHealthHandler : IInitializable, IDamageable
    {
        private readonly Settings _settings;
        public float CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0f;

        public EnemyHealthHandler(Settings settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            CurrentHealth = _settings.MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (!IsAlive)
                return;

            CurrentHealth = Mathf.Max(CurrentHealth - damage, 0f);
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
        }
    }
}