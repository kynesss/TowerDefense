using System;
using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class ArrowMovementHandler
    {
        private readonly Transform _transform;
        private readonly Settings _settings;

        public ArrowMovementHandler(Transform transform, Settings settings)
        {
            _transform = transform;
            _settings = settings;
        }

        public void FollowTarget(Vector3 targetPosition)
        {
            var direction = (targetPosition - _transform.position).normalized;
            
            MoveTowards(direction);   
            RotateTowards(direction);
        }

        private void MoveTowards(Vector3 direction)
        {
            _transform.position += direction * (_settings.Speed * Time.deltaTime);
        }

        private void RotateTowards(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Speed { get; private set; } = 10f;
        }
    }
}