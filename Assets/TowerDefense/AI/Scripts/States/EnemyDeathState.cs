using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyDeathState : EnemyStateEntity
    {
        private readonly EnemyMovement _movement;
        
        public EnemyDeathState(EnemyStateMachine stateMachine, EnemyMovement movement) : base(stateMachine)
        {
            _movement = movement;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Death State!");
            _movement.Stop();
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