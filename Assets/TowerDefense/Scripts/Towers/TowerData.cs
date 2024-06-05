using UnityEngine;

namespace TowerDefense.Scripts.Towers
{
    [CreateAssetMenu(menuName = "Towers/Tower", fileName = "Tower")]
    public class TowerData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite TowerSprite { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public TowerFacade Prefab { get; private set; }
        [field: SerializeField] public TowerData Upgrade { get; private set; }
    }
}
