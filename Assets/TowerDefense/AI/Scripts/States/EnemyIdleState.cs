using UnityEngine;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyIdleState : IEnemyState
    {
        public void Enter()
        {
            
        }

        public void Update()
        {
            Debug.Log($"Idle");
        }

        public void Exit()
        {
            
        }
    }
}