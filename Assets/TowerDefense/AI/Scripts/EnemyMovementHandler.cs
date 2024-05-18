using Pathfinding;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public class EnemyMovementHandler
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
    }
}