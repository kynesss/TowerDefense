using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI
{
    public class EnemyFacade : MonoBehaviour
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

        public class Factory : PlaceholderFactory<EnemyFacade>
        {
            
        } 
    }
}
