using System;
using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class TowerProjectileMovement
    {
        private readonly Transform _transform;
        private readonly Settings _settings;

        public TowerProjectileMovement(Transform transform, Settings settings)
        {
            _transform = transform;
            _settings = settings;
        }

        public void MoveTowards(Vector3 targetPosition)
        {
            var direction = (targetPosition - _transform.position).normalized;
            _transform.position += direction * _settings.Speed * Time.deltaTime;
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Speed { get; private set; } = 10f;
        }
    }
}