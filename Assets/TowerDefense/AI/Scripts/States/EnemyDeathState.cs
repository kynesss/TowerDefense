using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyDeathState : EnemyStateEntity
    {
        public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Death State!");
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