using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI
{
    public class EnemyFacade : MonoBehaviour
    {
        private readonly EnemyStateManager _stateManager;

        public EnemyState State => _stateManager.CurrentState;

        public EnemyFacade(EnemyStateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public class Factory : PlaceholderFactory<EnemyFacade>
        {
            
        }
    }
}
