using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.Projectiles
{
    // TODO: That should be MonoMemoryPool instead of MemoryPool or Factory
    public class TowerProjectile : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        
        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<TowerProjectile>
        {
            
        }
    }
}