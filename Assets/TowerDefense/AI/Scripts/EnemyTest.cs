using TowerDefense.Scripts.AI;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts
{
    public class EnemyTest : ITickable
    {
        private readonly EnemySpawner _spawner;

        public EnemyTest(EnemySpawner spawner)
        {
            _spawner = spawner;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"Space");
                
                _spawner.Spawn();
            }
        }
    }
}