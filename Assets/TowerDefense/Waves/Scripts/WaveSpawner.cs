using System.Collections.Generic;
using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Waves.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private int id;
        
        private List<Wave> _waves;
        private EnemyStateMachine.Factory _enemyFactory;

        [Inject]
        private void Construct(List<Wave> waves, EnemyStateMachine.Factory enemyFactory)
        {
            _waves = waves;
            _enemyFactory = enemyFactory;
        }

        private void Awake()
        {
            var wave = _waves[0];
            var waveData = wave.WaveData[id];
            var waveElements = waveData.Elements;
            
            foreach (var element in waveElements)
            {
                Debug.Log($"Spawner: {id} has {element.Count} {element.Prefab.name} prefab!");
            }
        }
    }
}