using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TowerDefense.Scripts.Towers
{
    public class TowerFacade : MonoBehaviour
    {
        [Header("Gizmos")]
        [SerializeField] private int segments = 50;
        
        private TowerAttackHandler _attackHandler;

        [Inject]
        private void Construct(TowerAttackHandler attackHandler)
        {
            _attackHandler = attackHandler;
        }
        
        public void SetParentAndPosition(Transform parent, Vector3 position)
        {
            transform.SetParent(parent);
            transform.position = position;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            _attackHandler.DrawRangeCircle(transform.position, segments);
        }
#endif
        
        public class Factory : PlaceholderFactory<Object, TowerFacade>
        {
            
        }
    }
}