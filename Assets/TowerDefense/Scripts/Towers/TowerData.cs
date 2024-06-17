using UnityEngine;

namespace TowerDefense.Scripts.Towers
{
    [CreateAssetMenu(menuName = "Towers/Tower", fileName = "Tower")]
    public class TowerData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int RequiredStars { get; private set; }
        [field: SerializeField] public int Prize { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public TowerFacade Prefab { get; private set; }
        [field: SerializeField] public TowerData Upgrade { get; private set; }

        public bool CanUpgrade => Upgrade != null;
        private bool UnlockedOnStart => RequiredStars == 0;

        public bool IsUnlocked()
        {
            return UnlockedOnStart || PlayerPrefs.HasKey(Name);
        }

        public bool TryUnlock(int starsAmount)
        {
            if (starsAmount < RequiredStars)
            {
                Debug.Log($"You need at least: {RequiredStars} to unlock this Tower!");
                return false;
            }
            
            // TODO: decrease Player's star amount
            PlayerPrefs.SetString(Name, "");
            
            return true;
        }
    }
}
