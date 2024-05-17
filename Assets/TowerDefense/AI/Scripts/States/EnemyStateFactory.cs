using System;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyStateFactory
    {
        private readonly EnemyIdleState.Factory _idleStateFactory;
        private readonly EnemyWalkState.Factory _walkStateFactory;

        public EnemyStateFactory(EnemyIdleState.Factory idleStateFactory, EnemyWalkState.Factory walkStateFactory)
        {
            _idleStateFactory = idleStateFactory;
            _walkStateFactory = walkStateFactory;
        }

        public EnemyStateEntity CreateState(EnemyState state)
        {
            return state switch
            {
                EnemyState.Idle => _idleStateFactory.Create(),
                EnemyState.Walk => _walkStateFactory.Create(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
    }
    public enum EnemyState
    {
        Idle,
        Walk
    }
}