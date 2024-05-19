using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyDeathState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyAnimationHandler _animationHandler;
        
        public EnemyDeathState(
            EnemyStateMachine stateMachine, 
            EnemyMovementHandler movementHandler, 
            EnemyAnimationHandler animationHandler) : base(stateMachine)
        {
            _movementHandler = movementHandler;
            _animationHandler = animationHandler;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Death State!");
            _movementHandler.Stop();
            _animationHandler.PlayStateAnimation(EnemyState.Death);
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