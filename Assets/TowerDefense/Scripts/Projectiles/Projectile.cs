using TowerDefense.Scripts.AI;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        private Transform _target;
        
        private Pool _pool;
        private ProjectileMovementHandler _movementHandler;
        private IProjectileDamageHandler _damageHandler;
        
        [Inject]
        private void Construct(
            Pool pool, 
            ProjectileMovementHandler movementHandler,
            IProjectileDamageHandler damageHandler)
        {
            _pool = pool;
            _movementHandler = movementHandler;
            _damageHandler = damageHandler;
        }

        private void SetTarget(Transform target)
        {
            _target = target;
        }
        
        private void Update()
        {
            if (_target != null)
            {
                _movementHandler.FollowTarget(_target.position);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _damageHandler.ApplyDamage(other);
            _pool.Despawn(this);
        }

        public class Pool : MonoMemoryPool<Transform, Projectile>
        {
            protected override void Reinitialize(Transform target, Projectile item)
            {
                item.SetTarget(target);
            }

            protected override void OnDespawned(Projectile item)
            {
                base.OnDespawned(item);
                item.SetTarget(null);
            }
        }
    }
}