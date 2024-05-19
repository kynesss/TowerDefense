using EasyButtons;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState previousState;
        [SerializeField] private EnemyState currentState;
        
        private EnemyStateFactory _stateFactory;
        private EnemyHealthHandler _healthHandler;
        private EnemyStateEntity _currentStateEntity;
        public bool IsAlive => _healthHandler.IsAlive;
        
        [Inject]
        private void Construct(
            EnemyStateFactory stateFactory,
            EnemyHealthHandler healthHandler)
        {
            _stateFactory = stateFactory;
            _healthHandler = healthHandler;
        }
        
        private void Start()
        {
            ChangeState(EnemyState.Walk);
        }

        private void Update()
        {
            if (!IsAlive && currentState != EnemyState.Death)
            {
                ChangeState(EnemyState.Death);
                return;
            }
            
            _currentStateEntity?.Tick();
        }
        
        [Button("ChangeState")]
        internal void ChangeState(EnemyState state)
        {
            _currentStateEntity?.Dispose();
            _currentStateEntity = _stateFactory.CreateState(state);
            _currentStateEntity.Initialize();
            
            previousState = currentState;
            currentState = state;
        }

        [Button("TakeDamage")]
        internal void TakeDamage(float damage)
        {
            _healthHandler.TakeDamage(damage);
        }

        public class Factory : PlaceholderFactory<Object, EnemyStateMachine>
        {
            
        }
    }
}