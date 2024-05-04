using TowerDefense.Scripts.AI.States;

namespace TowerDefense.AI.Scripts.Signals
{
    public class EnemyStateChangedSignal
    {
        public EnemyState PreviousState { get; private set; }
        public EnemyState CurrentState { get; private set; }
        
        public EnemyStateChangedSignal(EnemyState previousState, EnemyState currentState)
        {
            PreviousState = previousState;
            CurrentState = currentState;
        }
    }
}