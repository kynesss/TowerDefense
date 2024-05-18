using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyWalkState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        public EnemyWalkState(EnemyStateMachine stateMachine, EnemyMovementHandler movementHandler) : base(stateMachine)
        {
            _movementHandler = movementHandler;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Walk State!");
        }

        public override void Tick()
        {
            _movementHandler.MoveTo(new Vector3(-19, -16));
        }

        public override void Dispose()
        {
            Debug.Log($"Dispose Walk State!");
        }

        public class Factory : PlaceholderFactory<EnemyWalkState>
        {
            
        }
    }
}