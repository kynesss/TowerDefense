using UnityEngine;

namespace TowerDefense.Scripts.Towers
{
    [CreateAssetMenu(menuName = "Towers/Tower", fileName = "Tower")]
    public class Tower : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite TowerSprite { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public AnimatorOverrideController AnimatorController { get; private set; }
        [field: SerializeField] public Tower Upgrade { get; private set; }
        
        public void Update()
        {
            Debug.Log($"{Name}");
        }
    }
}
