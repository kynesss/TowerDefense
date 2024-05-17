using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyIdleState : EnemyStateEntity
    {
        public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Initialize()
        {
            Debug.Log("Initialize Idle State!");
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