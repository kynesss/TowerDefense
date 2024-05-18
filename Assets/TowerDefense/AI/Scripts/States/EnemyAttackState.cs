using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyAttackState : EnemyStateEntity
    {
        public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Attack State!");
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