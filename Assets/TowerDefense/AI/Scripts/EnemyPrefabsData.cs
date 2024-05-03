using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    [CreateAssetMenu(menuName = "Enemy/PrefabsData", fileName = "EnemyPrefabsData")]
    public class EnemyPrefabsData : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<EnemyType, Enemy> enemyTypeToPrefab;

        public Enemy GetEnemyPrefabByType(EnemyType type)
        {
            return enemyTypeToPrefab[type];
        }
    }
}