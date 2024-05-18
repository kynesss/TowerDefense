using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyFollowState : EnemyStateEntity
    {
        private readonly EnemyMovement _movement;
        private readonly EnemyTargetDetection _targetDetection;
        private readonly Settings _settings;

        public EnemyFollowState(
            EnemyStateMachine stateMachine, 
            EnemyMovement movement,
            EnemyTargetDetection targetDetection,
            Settings settings) : base(stateMachine)
        {
            _movement = movement;
            _targetDetection = targetDetection;
            _settings = settings;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Follow State!");
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
            
            _movement.MoveTo(targetPosition);
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