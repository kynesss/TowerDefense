using System;
using EasyButtons;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        private Pool _pool;
        private IProjectileDamageHandler _damageHandler;
        private ProjectileAnimationHandler _animationHandler;
        private ProjectilePhysicsHandler _physicsHandler;
        public Transform Target { get; private set; }
        public event Action<Transform> TargetChanged;

        [Inject]
        private void Construct(
            Pool pool,
            IProjectileDamageHandler damageHandler,
            ProjectileAnimationHandler animationHandler,
            ProjectilePhysicsHandler physicsHandler)
        {
            _pool = pool;
            _damageHandler = damageHandler;
            _animationHandler = animationHandler;
            _physicsHandler = physicsHandler;
        }

        [Button]
        public void Despawn()
        {
            if (gameObject.activeSelf)
                _pool.Despawn(this);
        }

        public void OnHit(Collider2D other = null)
        {
            _physicsHandler.SetPhysicsEnabled(false);
            _animationHandler.PlayHitAnimation();
            
            if (other != null)
                _damageHandler.ApplyDamage(other);
            else
                _damageHandler.ApplyDamage();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnHit(other);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetTarget(Transform target)
        {
            Target = target;
            TargetChanged?.Invoke(target);
        }
        
        public class Pool : MonoMemoryPool<Projectile>
        {
            protected override void Reinitialize(Projectile item)
            {
                item._physicsHandler.SetPhysicsEnabled(true);
            }
        }
    }
}