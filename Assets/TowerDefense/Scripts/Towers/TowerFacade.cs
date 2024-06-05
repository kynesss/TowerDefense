using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerFacade : MonoBehaviour
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
        
        public class Factory : PlaceholderFactory<Object, TowerFacade>
        {
            
        }
    }
}