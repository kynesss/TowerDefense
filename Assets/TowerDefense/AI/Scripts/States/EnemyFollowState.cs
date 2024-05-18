using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyFollowState : EnemyStateEntity
    {
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyAnimationHandler _animationHandler;
        private readonly EnemyTargetDetection _targetDetection;
        private readonly Settings _settings;

        public EnemyFollowState(
            EnemyStateMachine stateMachine, 
            EnemyMovementHandler movementHandler,
            EnemyAnimationHandler animationHandler,
            EnemyTargetDetection targetDetection, 
            Settings settings) : base(stateMachine)
        {
            _movementHandler = movementHandler;
            _animationHandler = animationHandler;
            _targetDetection = targetDetection;
            _settings = settings;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Follow State!");
            _animationHandler.PlayStateAnimation(EnemyState.Follow);
        }

        public override void Tick()
        {
            if (!_targetDetection.HasTarget)
            {
                StateMachine.ChangeState(EnemyState.Walk);
                return;
            }

            var position = StateMachine.transform.position;
            var targetPosition = _targetDetection.Target.transform.position;
            var distanceToTarget = Vector3.Distance(position, targetPosition);
            
            if (distanceToTarget <= _settings.MaxDistanceToTarget)
            {
                StateMachine.ChangeState(EnemyState.Attack);
                return;
            }
            
            _movementHandler.MoveTo(targetPosition);
        }

        public override void Dispose()
        {
            Debug.Log($"Dispose Follow State!");
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float MaxDistanceToTarget { get; private set; }
        }

        public class Factory : PlaceholderFactory<EnemyFollowState>
        {
        }
    }
}