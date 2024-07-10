using System;
using TowerDefense.Scripts.AI;
using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class StoneDamageHandler : IProjectileDamageHandler
    {
        private readonly Settings _settings;
        private readonly Transform _transform;

        public StoneDamageHandler(Settings settings, Transform transform)
        {
            _settings = settings;
            _transform = transform;
        }
        
        public void ApplyDamage(Collider2D collision = null)
        {
            var center = _transform.position;
            var results = new Collider2D[10];
            
            var hitInfo = Physics2D.OverlapCircleNonAlloc(center, _settings.CollisionRadius, results, _settings.CollisionLayer);
            
            if (hitInfo == 0)
                return;

            foreach (var collider in results)
            {
                if (collider == null)
                    continue;

                if (!collider.TryGetComponent<EnemyStateMachine>(out var enemy))
                    continue;
                
                Debug.LogError($"Apply Damage to {enemy.gameObject.name}");
                enemy.TakeDamage(_settings.Damage);
            }
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Damage { get; private set; } = 10f;
            [field: SerializeField] public float CollisionRadius { get; private set; } = 3f;
            [field: SerializeField] public LayerMask CollisionLayer { get; private set; }
        }
    }
}