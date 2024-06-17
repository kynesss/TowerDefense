using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerAttackHandler : ITickable
    {
        private readonly Settings _settings;
        private readonly Transform _transform;

        private Collider2D _targetCollider;
        private Collider2D[] _results = new Collider2D[10];
        private bool HasTarget => _targetCollider != null && _results.Contains(_targetCollider);

        public TowerAttackHandler(Settings settings, Transform transform)
        {
            _settings = settings;
            _transform = transform;
        }

        public void Tick()
        {
            _results = new Collider2D[10];
            var hitInfo = Physics2D.OverlapCircleNonAlloc(_transform.position, _settings.RangeRadius, _results, _settings.TargetLayerMask);
            if (hitInfo == 0) 
                return;
            
            if (HasTarget)
            {
                Debug.Log($"Target is: {_targetCollider.gameObject.name}");
            }
            else
            {
                foreach (var result in _results)
                {
                    if (result == null)
                        continue;

                    _targetCollider = result;
                    Debug.LogError($"Result: {result.gameObject.name}");
                }
            }
        }

        public void DrawRangeCircle(Vector3 center, int segments)
        {
            var angle = 0f;
            var lastPosition = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * _settings.RangeRadius;

            for (var i = 1; i <= segments; i++)
            {
                angle += 2 * Mathf.PI / segments;
                var newPosition = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * _settings.RangeRadius;
                
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(lastPosition, newPosition);

                lastPosition = newPosition;
            }
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float RangeRadius { get; private set; }
            [field: SerializeField] public float Rate { get; private set; }
            [field: SerializeField] public LayerMask TargetLayerMask { get; private set; }
        }
    }
}