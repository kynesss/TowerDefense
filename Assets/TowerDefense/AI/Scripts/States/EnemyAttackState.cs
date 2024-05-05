using TowerDefense.AI.Scripts;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyAttackState : IEnemyState
    {
        private readonly IEnemyMovementHandler _movementHandler;

        public EnemyAttackState(IEnemyMovementHandler movementHandler)
        {
            _movementHandler = movementHandler;
        }

        public void Enter()
        {
            _movementHandler.Stop();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}