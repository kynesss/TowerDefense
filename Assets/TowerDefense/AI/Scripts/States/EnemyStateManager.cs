using System.Collections.Generic;
using TowerDefense.AI.Scripts.Signals;
using TowerDefense.Scripts.AI.States;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public class EnemyStateManager : IInitializable, ITickable
    {
        private readonly List<IEnemyState> _stateHandlers;
        private readonly SignalBus _signalBus;

        private IEnemyState _currentStateHandler;
        public EnemyState CurrentState { get; private set; }

        public EnemyStateManager(
            EnemyIdleState idleState,
            EnemyWalkState walkState,
            EnemyFollowState followState,
            EnemyAttackState attackState,
            EnemyDeathState deathState, 
            SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            _stateHandlers = new List<IEnemyState>()
            {
                idleState, walkState, followState, attackState, deathState
            };
        }

        public void Initialize()
        {
            ChangeState(EnemyState.Walk);
        }

        public void Tick()
        {
            _currentStateHandler?.Update();
        }
        
        public void ChangeState(EnemyState newState)
        {
            if (newState == CurrentState)
                return;

            var lastState = CurrentState;
            CurrentState = newState;

            _currentStateHandler?.Exit();
            _currentStateHandler = _stateHandlers[(int)newState];
            _currentStateHandler.Enter();
            
            _signalBus.Fire(new EnemyStateChangedSignal(lastState, newState));
        }
    }
}