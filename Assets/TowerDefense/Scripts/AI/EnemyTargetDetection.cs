using UnityEngine;

namespace TowerDefense.Scripts.AI
{
    public class EnemyTargetDetection : MonoBehaviour
    {
        public DummySoldier Target { get; private set; }
        public bool HasTarget => Target != null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (HasTarget)
                return;
            
            if (other.TryGetComponent<DummySoldier>(out var target))
            {
                Target = target;
            }            
        }
    }
}
