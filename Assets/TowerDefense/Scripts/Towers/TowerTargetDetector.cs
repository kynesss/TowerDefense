using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerTargetDetector : ITickable
    {
        private readonly Settings _settings;
        private readonly Transform _transform;
        private readonly SignalBus _signalBus;

        private Collider2D _targetCollider;
        private Collider2D[] _results = new Collider2D[10];
        public bool HasTarget => _targetCollider != null && _results.Contains(_targetCollider);
        public Transform Target => _targetCollider.transform;
        
        public TowerTargetDetector(Settings settings, Transform transform, SignalBus signalBus)
        {
            _settings = settings;
            _transform = transform;
            _signalBus = signalBus;
        }

        public void Tick()
        {
            _results = new Collider2D[10];
            
            var hitInfo = Physics2D.OverlapCircleNonAlloc(_transform.position, _settings.RangeRadius, _results,
                _settings.TargetLayerMask);

            if (hitInfo == 0)
                return;

            if (HasTarget)
                return;

            FindTargetInRange();
        }

        private void FindTargetInRange()
        {
            foreach (var result in _results)
            {
                if (result == null)
                    continue;

                SetTarget(result);
            }
        }

        private void SetTarget(Collider2D result)
        {
            _targetCollider = result;
            _signalBus.Fire(new TowerTargetChangedSignal(Target));
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
            [field: SerializeField] public LayerMask TargetLayerMask { get; private set; }
        }
    }
}