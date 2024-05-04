using System;
using Pathfinding;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public class EnemyMovementHandler : IEnemyMovementHandler
    {
        private readonly IAstarAI _ai;
        private readonly Settings _settings;

        public EnemyMovementHandler(IAstarAI ai, Settings settings)
        {
            _ai = ai;
            _settings = settings;

            _ai.maxSpeed = _settings.Speed;
        }

        public void MoveTo(Vector3 destination)
        {
            _ai.isStopped = false;
            _ai.destination = destination;
        }

        public void Stop()
        {
            _ai.isStopped = true;
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Speed { get; private set; }
        }
    }
}