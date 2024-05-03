using System.Collections.Generic;
using TowerDefense.Scripts.AI.States;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyStateManager : IInitializable, ITickable
    {
        private readonly List<IEnemyState> _stateHandlers;

        private IEnemyState _currentStateHandler;
        public EnemyState CurrentState { get; private set; }

        public EnemyStateManager(
            EnemyIdleState idleState,
            EnemyWalkState walkState,
            EnemyFollowState followState,
            EnemyAttackState attackState,
            EnemyDeathState deathState)
        {
            _stateHandlers = new List<IEnemyState>()
            {
                idleState, walkState, followState, attackState, deathState
            };
        }

        public void Initialize()
        {
            ChangeState(EnemyState.Idle);
        }

        public void Tick()
        {
            _currentStateHandler?.Update();
        }

        public void ChangeState(EnemyState state)
        {
            if (state == CurrentState)
                return;

            _currentStateHandler?.Exit();
            
            CurrentState = state;
            
            _currentStateHandler = _stateHandlers[(int)state];
            _currentStateHandler.Enter();
        }
    }
}