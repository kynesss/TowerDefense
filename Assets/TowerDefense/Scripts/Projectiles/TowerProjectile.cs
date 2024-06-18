using TowerDefense.Scripts.AI;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class TowerProjectile : MonoBehaviour
    {
        private Transform _target;
        
        private Pool _pool;
        private TowerProjectileMovement _movement;
        
        [Inject]
        private void Construct(Pool pool, TowerProjectileMovement movement)
        {
            _pool = pool;
            _movement = movement;
        }

        private void SetTarget(Transform target)
        {
            _target = target;
        }
        
        private void Update()
        {
            if (_target != null)
            {
                _movement.MoveTowards(_target.position);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<EnemyStateMachine>(out var enemy))
            {
                _pool.Despawn(this);
            }
        }

        public class Pool : MonoMemoryPool<Transform, TowerProjectile>
        {
            protected override void Reinitialize(Transform target, TowerProjectile item)
            {
                item.SetTarget(target);
            }

            protected override void OnDespawned(TowerProjectile item)
            {
                base.OnDespawned(item);
                item.SetTarget(null);
            }
        }
    }
}