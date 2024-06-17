using UnityEngine;

namespace TowerDefense.Scripts.Towers
{
    [CreateAssetMenu(menuName = "Towers/Tower", fileName = "Tower")]
    public class TowerData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int RequiredStars { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public TowerFacade Prefab { get; private set; }
        [field: SerializeField] public TowerData Upgrade { get; private set; }

        public bool CanUpgrade => Upgrade != null;
        private bool UnlockedOnStart => RequiredStars == 0;

        public bool IsUnlocked()
        {
            if (UnlockedOnStart)
                return true;

            // TODO: Load Player's stars and compare them with RequiredStars
            
            return false;
        }
    }
}
