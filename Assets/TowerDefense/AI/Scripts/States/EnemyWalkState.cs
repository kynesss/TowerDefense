using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyWalkState : EnemyStateEntity
    {
        private readonly EnemyMovement _movement;
        private readonly EnemyTargetDetection _targetDetection;
        public EnemyWalkState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyTargetDetection targetDetection) : base(stateMachine)
        {
            _movement = movement;
            _targetDetection = targetDetection;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Walk State!");
        }

        public override void Tick()
        {
            if (_targetDetection.HasTarget)
            {
                StateMachine.ChangeState(EnemyState.Follow);
                return;
            }
            
            _movement.MoveTo(new Vector3(-19, -16));
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