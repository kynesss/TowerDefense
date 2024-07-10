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
        public Transform Target { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        public event Action<Transform> TargetChanged;  

        [Inject]
        private void Construct(
            Pool pool, 
            IProjectileDamageHandler damageHandler, 
            Rigidbody2D rb,
            ProjectileAnimationHandler animationHandler)
        {
            _pool = pool;
            _damageHandler = damageHandler;
            Rigidbody = rb;
            _animationHandler = animationHandler;
        }

        [Button]
        public void Despawn()
        {
            if (gameObject.activeSelf)
                _pool.Despawn(this);
        }

        public void OnHit()
        {
            Rigidbody.simulated = false;
            _animationHandler.PlayHitAnimation();   
        }
        
        // TODO: PhysicsHandler
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnHit();
            _damageHandler.ApplyDamage(other);
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
                item.Rigidbody.simulated = true;
            }
        }
    }
}