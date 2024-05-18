using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyAttackState : EnemyStateEntity
    {
        private readonly EnemyMovement _movement;
        
        public EnemyAttackState(EnemyStateMachine stateMachine, EnemyMovement movement) : base(stateMachine)
        {
            _movement = movement;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Attack State!");
            _movement.Stop();
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