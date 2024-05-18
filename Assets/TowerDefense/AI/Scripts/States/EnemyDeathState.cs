using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyDeathState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        
        public EnemyDeathState(EnemyStateMachine stateMachine, EnemyMovementHandler movementHandler) : base(stateMachine)
        {
            _movementHandler = movementHandler;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Death State!");
            _movementHandler.Stop();
        }

        public override void Tick()
        {
            
        }

        public override void Dispose()
        {
            Debug.Log($"Dispose Death State!");
        }

        public class Factory : PlaceholderFactory<EnemyDeathState>
        {
            
        } 
    }
}