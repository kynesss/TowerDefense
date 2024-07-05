﻿using System;
using EasyButtons;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        private Pool _pool;
        private IProjectileDamageHandler _damageHandler;
        public Transform Target { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        public event Action<Transform> TargetChanged;  

        [Inject]
        private void Construct(
            Pool pool, 
            IProjectileDamageHandler damageHandler, 
            Rigidbody2D rb)
        {
            _pool = pool;
            _damageHandler = damageHandler;
            Rigidbody = rb;
        }

        [Button]
        public void Despawn()
        {
            if (gameObject.activeSelf)
                _pool.Despawn(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _damageHandler.ApplyDamage(other);
            Despawn();
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

        }
    }
}