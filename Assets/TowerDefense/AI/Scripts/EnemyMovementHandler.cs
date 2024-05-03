using Pathfinding;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public class EnemyMovementHandler : IEnemyMovementHandler
    {
        private readonly IAstarAI _ai;

        public EnemyMovementHandler(IAstarAI ai)
        {
            _ai = ai;
        }

        public void MoveTo(Vector3 destination)
        {
            _ai.destination = destination;
        }

        public void Stop()
        {
            //_ai.destination = null;
        }
    }
}