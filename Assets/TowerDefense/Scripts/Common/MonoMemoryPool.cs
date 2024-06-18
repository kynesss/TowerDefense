using UnityEngine;
using Zenject;
namespace TowerDefense.Scripts.Common
{
    public abstract class MonoMemoryPool<TValue> : MemoryPool<TValue>
        where TValue : Component
    {
        private Transform _originalParent;

        protected override void OnCreated(TValue item)
        {
            item.gameObject.SetActive(false);
            _originalParent = item.transform.parent;
        }

        protected override void OnDestroyed(TValue item)
        {
            Object.Destroy(item.gameObject);
        }

        protected override void OnSpawned(TValue item)
        {
            item.gameObject.SetActive(true);
        }

        protected override void OnDespawned(TValue item)
        {
            item.gameObject.SetActive(false);

            if (item.transform.parent != _originalParent)
            {
                item.transform.SetParent(_originalParent, false);
            }
        }
    }
}