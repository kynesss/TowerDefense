using System;
using TowerDefense.AI.Scripts.States;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TowerDefense.AI.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private EnemyStateManager _stateManager;
        public EnemyState State => _stateManager.CurrentState;
        
        [Inject]
        public void Construct(EnemyStateManager stateManager)
        {
            _stateManager = stateManager;
        }
        
        private void Update()
        {
            Debug.Log($"Current state: {State}");
        }

        public class Factory : PlaceholderFactory<Object, Enemy>
        {
            
        }
    }
}
