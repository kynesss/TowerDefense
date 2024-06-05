using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerFacade : MonoBehaviour
    {
        public void SetParentAndPosition(Transform parent, Vector3 position)
        {
            transform.SetParent(parent);
            transform.position = position;
        }
        
        public class Factory : PlaceholderFactory<Object, TowerFacade>
        {
            
        }
    }
}