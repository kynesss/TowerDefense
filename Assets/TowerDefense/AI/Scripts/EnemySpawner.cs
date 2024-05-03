using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public class EnemySpawner
    {
        private readonly Enemy.Factory _factory;
        private readonly EnemyPrefabsData _prefabsData;
        
        private Vector2 _tempSpawnPoint = new(18f, 16f);
        
        public EnemySpawner(Enemy.Factory factory, EnemyPrefabsData prefabsData)
        {
            _factory = factory;
            _prefabsData = prefabsData;
        }

        public void Spawn(EnemyType type)
        {
            var prefab = _prefabsData.GetEnemyPrefabByType(type);
            var enemy = _factory.Create(prefab);
            
            enemy.transform.position = _tempSpawnPoint;
            _tempSpawnPoint += Vector2.down * 2f;
        }
    }
}