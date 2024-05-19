﻿using EasyButtons;
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
        private EnemyStateEntity _currentStateEntity;
        
        [Inject]
        private void Construct(EnemyStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        private void Start()
        {
            ChangeState(EnemyState.Walk);
        }

        private void Update()
        {
            _currentStateEntity?.Tick();
        }
        
        [Button]
        internal void ChangeState(EnemyState state)
        {
            _currentStateEntity?.Dispose();
            _currentStateEntity = _stateFactory.CreateState(state);
            _currentStateEntity.Initialize();
            
            previousState = currentState;
            currentState = state;
        }

        public class Factory : PlaceholderFactory<Object, EnemyStateMachine>
        {
            
        }
    }
}