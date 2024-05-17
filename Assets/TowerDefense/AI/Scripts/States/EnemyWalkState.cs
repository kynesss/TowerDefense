using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyWalkState : EnemyStateEntity
    {
        public EnemyWalkState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Walk State!");
        }

        public override void Tick()
        {
            
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