using TowerDefense.Scripts.AI;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.Projectiles
{
    public class TowerProjectile : MonoBehaviour
    {
        private Transform _target;
        private Pool _pool;
        
        [Inject]
        private void Construct(Pool pool)
        {
            _pool = pool;
        }

        private void SetTarget(Transform target)
        {
            _target = target;
        }
        
        private void Update()
        {
            if (_target != null)
            {
                var direction = (_target.position - transform.position).normalized;
                transform.position += direction * 10f * Time.deltaTime;
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