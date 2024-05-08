using TowerDefense.AI.Scripts;
using UnityEngine;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyWalkState : IEnemyState
    {
        private readonly IEnemyMovementHandler _movementHandler;
        private readonly Vector3 _destination;
        public EnemyWalkState(IEnemyMovementHandler movementHandler, Vector3 destination)
        {
            _movementHandler = movementHandler;
            _destination = destination;
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            _movementHandler.MoveTo(_destination);
        }

        public void Exit()
        {
            
        }
    }
}