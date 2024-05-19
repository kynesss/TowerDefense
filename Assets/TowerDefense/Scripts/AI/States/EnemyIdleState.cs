using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyIdleState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyAnimationHandler _animationHandler;
        
        public EnemyIdleState(
            EnemyStateMachine stateMachine,
            EnemyMovementHandler movementHandler,
            EnemyAnimationHandler animationHandler) : base(stateMachine)
        {
            _movementHandler = movementHandler;
            _animationHandler = animationHandler;
        }

        public override void Initialize()
        {
            Debug.Log("Initialize Idle State!");
            _movementHandler.Stop();
            _animationHandler.PlayStateAnimation(EnemyState.Idle);
        }

        public override void Tick()
        {
               
        }

        public override void Dispose()
        {
            Debug.Log("Dispose Idle State!");
        }

        public class Factory : PlaceholderFactory<EnemyIdleState>
        {
            
        }
    }
}