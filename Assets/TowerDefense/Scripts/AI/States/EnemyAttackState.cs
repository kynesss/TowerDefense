using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyAttackState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyAnimationHandler _animationHandler;
        
        public EnemyAttackState(
            EnemyStateMachine stateMachine, 
            EnemyMovementHandler movementHandler, 
            EnemyAnimationHandler animationHandler) : base(stateMachine)
        {
            _movementHandler = movementHandler;
            _animationHandler = animationHandler;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Attack State!");
            _movementHandler.Stop();
            _animationHandler.PlayStateAnimation(EnemyState.Attack);
        }

        public override void Tick()
        {
            
        }

        public override void Dispose()
        {
            Debug.Log($"Dispose Attack State!");
        }

        public class Factory : PlaceholderFactory<EnemyAttackState>
        {
            
        }
    }
}