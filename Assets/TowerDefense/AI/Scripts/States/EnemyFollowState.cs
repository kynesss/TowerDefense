using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyFollowState : EnemyStateEntity
    {
        public EnemyFollowState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Follow State!");
        }

        public override void Tick()
        {
            
        }

        public override void Dispose()
        {
            Debug.Log($"Dispose Follow State!");
        }

        public class Factory : PlaceholderFactory<EnemyFollowState>
        {
            
        }
    }
}