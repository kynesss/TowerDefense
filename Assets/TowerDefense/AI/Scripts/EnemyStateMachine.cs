using System;
using TowerDefense.AI.Scripts.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState previousState;
        [SerializeField] private EnemyState currentState;
        
        private EnemyStateFactory _stateFactory;
        private EnemyStateEntity _currentStateEntity;

        [Inject]
        private void Construct(EnemyStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        private void Start()
        {
            ChangeState(EnemyState.Idle);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(EnemyState.Walk);
            }
        }

        private void ChangeState(EnemyState state)
        {
            _currentStateEntity?.Dispose();
            _currentStateEntity = _stateFactory.CreateState(state);
            _currentStateEntity.Initialize();
            
            previousState = currentState;
            currentState = state;
        }
    }
}