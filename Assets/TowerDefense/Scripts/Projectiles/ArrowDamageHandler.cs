using System;
using TowerDefense.Scripts.AI;
using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class ArrowDamageHandler : IProjectileDamageHandler
    {
        private readonly Settings _settings;

        public ArrowDamageHandler(Settings settings)
        {
            _settings = settings;
        }

        public void ApplyDamage(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyStateMachine>(out var enemy))
            {
                enemy.TakeDamage(_settings.Damage);
            }
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Damage { get; private set; } = 10f;
        }
    }
}