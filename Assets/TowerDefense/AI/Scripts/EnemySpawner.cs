using UnityEngine;

namespace TowerDefense.Scripts.AI
{
    public class EnemySpawner
    {
        private readonly EnemyFacade.Factory _enemyFactory;

        private Vector2 _tempSpawnPoint = new(18f, 16f);
        
        public EnemySpawner(EnemyFacade.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Spawn()
        {
            var enemy = _enemyFactory.Create();
            enemy.transform.position = _tempSpawnPoint;

            _tempSpawnPoint += Vector2.down * 2f;
        }
    }
}