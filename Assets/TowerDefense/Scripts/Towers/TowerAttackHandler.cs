using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerAttackHandler : ITickable
    {
        private readonly Settings _settings;

        public TowerAttackHandler(Settings settings)
        {
            _settings = settings;
        }

        public void Tick()
        {
            
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
        }
    }
}