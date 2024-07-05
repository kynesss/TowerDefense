using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TowerDefense.Scripts.Towers
{
    public class TowerFacade : MonoBehaviour
    {
        [Header("Gizmos")]
        [SerializeField] private int segments = 50;
        
        private TowerTargetDetector _targetDetector;
        private TowerAttackHandler _attackHandler;

        [Inject]
        private void Construct(TowerTargetDetector targetDetector, TowerAttackHandler attackHandler)
        {
            _targetDetector = targetDetector;
            _attackHandler = attackHandler;
        }
        
        public void SetParentAndPosition(Transform parent, Vector3 position)
        {
            transform.SetParent(parent);
            transform.position = position;
        }

        public void Attack()
        {
            _attackHandler.AttackInstantly();
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            _targetDetector.DrawRangeCircle(transform.position, segments);
        }
#endif
        
        public class Factory : PlaceholderFactory<Object, TowerFacade>
        {
            
        }
    }
}