using NaughtyAttributes;
using TowerDefense.AI.Scripts.States;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TowerDefense.AI.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyState testState;
        
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

        [Button("ChangeState")]
        public void ChangeState()
        {
            _stateManager.ChangeState(testState);
        }

        public class Factory : PlaceholderFactory<Object, Enemy>
        {
            
        }
    }
}
