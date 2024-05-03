using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public class EnemySpawner
    {
        private readonly Enemy.Factory _enemyFactory;

        private Vector2 _tempSpawnPoint = new(18f, 16f);

        private readonly Object _prefab;
        public EnemySpawner(Enemy.Factory enemyFactory, Object prefab)
        {
            _enemyFactory = enemyFactory;
            _prefab = prefab;
        }

        public void Spawn()
        {
            var enemy = _enemyFactory.Create(_prefab);
            enemy.transform.position = _tempSpawnPoint;

            _tempSpawnPoint += Vector2.down * 2f;
        }
    }
}