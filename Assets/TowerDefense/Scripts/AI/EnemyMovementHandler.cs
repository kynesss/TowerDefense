using System;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemyMovementHandler : IInitializable
    {
        private readonly IAstarAI _ai;
        private readonly Settings _settings;

        public EnemyMovementHandler(IAstarAI ai, Settings settings)
        {
            _ai = ai;
            _settings = settings;
        }

        public void Initialize()
        {
            _ai.maxSpeed = _settings.Speed;
        }

        public void MoveTo(Vector3 destination)
        {
            _ai.canMove = true;
            _ai.destination = destination;
        }

        public void Stop()
        {
            _ai.canMove = false;
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Speed { get; private set; }
        }
    }
}