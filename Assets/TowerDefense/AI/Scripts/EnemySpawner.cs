using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [Required, SerializeField] private EnemySpawnerData data;

        private readonly Queue<EnemyType> _enemyTypeToSpawn = new();
        
        private Enemy.Factory _factory;
        private EnemyPrefabsData _prefabsData;

        [Inject]
        public void Construct(Enemy.Factory factory, EnemyPrefabsData prefabsData)
        {
            _factory = factory;
            _prefabsData = prefabsData;
        }

        private void Awake()
        {
            PrepareWave(3);
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(SpawnWave), data.SpawnRate, data.SpawnRate);
        }

        private void PrepareWave(int waveNumber)
        {
            var wave = data.Waves[waveNumber].Wave;

            foreach (var (type, amount) in wave)
            {
                for (var i = 0; i < amount; i++)
                {
                    _enemyTypeToSpawn.Enqueue(type);
                }
            }
        }

        private void SpawnWave()
        {
            if (_enemyTypeToSpawn.TryDequeue(out var enemyType))
            {
                Spawn(enemyType);
            }
        }

        public void Spawn(EnemyType type)
        {
            var prefab = _prefabsData.GetEnemyPrefabByType(type);
            var enemy = _factory.Create(prefab);
            
            enemy.transform.position = transform.position;
        }
    }
}