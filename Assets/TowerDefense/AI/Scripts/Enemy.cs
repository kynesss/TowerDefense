using System;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TowerDefense.AI.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private EnemyStateManager _stateManager;
        private Settings _settings;
        public EnemyState State => _stateManager.CurrentState;
        
        [Inject]
        public void Construct(EnemyStateManager stateManager, Settings settings)
        {
            _stateManager = stateManager;
            _settings = settings;
        }
        
        private void Update()
        {
            //Debug.Log($"Current state: {State}");
            
            Debug.Log($"Display name: {_settings.DisplayName}");
        }

        public class Factory : PlaceholderFactory<Object, Enemy>
        {
            
        }

        [Serializable]
        public class Settings
        {
            public string DisplayName;
        }
    }
}
