using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public class EnemyTargetDetection : MonoBehaviour
    {
        public DummySoldier Target { get; private set; }
        public bool HasTarget => Target != null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<DummySoldier>(out var target))
            {
                Target = target;
            }            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<DummySoldier>(out var target))
            {
                Target = null;
            }            
        }
    }
}
