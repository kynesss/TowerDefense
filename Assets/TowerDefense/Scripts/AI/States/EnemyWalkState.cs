using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyWalkState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyTargetDetection _targetDetection;
        private readonly EnemyAnimationHandler _animationHandler;

        public EnemyWalkState(
            EnemyStateMachine stateMachine,
            EnemyMovementHandler movementHandler,
            EnemyTargetDetection targetDetection, EnemyAnimationHandler animationHandler) : base(stateMachine)
        {
            _movementHandler = movementHandler;
            _targetDetection = targetDetection;
            _animationHandler = animationHandler;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Walk State!");
            _animationHandler.PlayStateAnimation(EnemyState.Walk);
        }

        public override void Tick()
        {
            if (_targetDetection.HasTarget)
            {
                StateMachine.ChangeState(EnemyState.Follow);
                return;
            }

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