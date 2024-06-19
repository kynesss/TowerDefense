﻿using UnityEngine;
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

        private void Despawn()
        {
            if (gameObject.activeSelf)
                _pool.Despawn(this);
        }
        
        private void Update()
        {
            if (_target == null) 
                return;

            var position = transform.position;
            var targetPosition = _target.position;

            if (Vector3.SqrMagnitude(position - targetPosition) < 0.05f)
            {
                Despawn();
                return;
            }
            
            _movementHandler.FollowTarget(targetPosition);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _damageHandler.ApplyDamage(other);
            Despawn();
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