using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyDeathState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyAnimationHandler _animationHandler;
        private readonly Collider2D _collider;
        
        public EnemyDeathState(
            EnemyStateMachine stateMachine, 
            EnemyMovementHandler movementHandler, 
            EnemyAnimationHandler animationHandler, 
            Collider2D collider) : base(stateMachine)
        {
            _movementHandler = movementHandler;
            _animationHandler = animationHandler;
            _collider = collider;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Death State!");
            _collider.enabled = false;
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