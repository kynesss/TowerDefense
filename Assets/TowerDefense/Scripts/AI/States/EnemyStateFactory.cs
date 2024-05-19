using System;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyStateFactory
    {
        private readonly EnemyIdleState.Factory _idleStateFactory;
        private readonly EnemyWalkState.Factory _walkStateFactory;
        private readonly EnemyFollowState.Factory _followStateFactory;
        private readonly EnemyAttackState.Factory _attackStateFactory;
        private readonly EnemyDeathState.Factory _deathStateFactory;

        public EnemyStateFactory(
            EnemyIdleState.Factory idleStateFactory,
            EnemyWalkState.Factory walkStateFactory,
            EnemyFollowState.Factory followStateFactory,
            EnemyAttackState.Factory attackStateFactory,
            EnemyDeathState.Factory deathStateFactory)
        {
            _idleStateFactory = idleStateFactory;
            _walkStateFactory = walkStateFactory;
            _followStateFactory = followStateFactory;
            _attackStateFactory = attackStateFactory;
            _deathStateFactory = deathStateFactory;
        }

        public EnemyStateEntity CreateState(EnemyState state)
        {
            return state switch
            {
                EnemyState.Idle => _idleStateFactory.Create(),
                EnemyState.Walk => _walkStateFactory.Create(),
                EnemyState.Follow => _followStateFactory.Create(),
                EnemyState.Attack => _attackStateFactory.Create(),
                EnemyState.Death => _deathStateFactory.Create(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
    }

    public enum EnemyState
    {
        Idle,
        Walk,
        Follow,
        Attack,
        Death
    }
}