using System.Collections.Generic;
using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Waves.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        private List<Wave> _waves;
        private EnemyStateMachine.Factory _enemyFactory;

        private int _id;

        [Inject]
        private void Construct(List<Wave> waves, EnemyStateMachine.Factory enemyFactory)
        {
            _waves = waves;
            _enemyFactory = enemyFactory;
        }

        private void Awake()
        {
            var wave = _waves[0];
            var waveData = wave.WaveData[_id];
            var waveElements = waveData.Elements;
            
            foreach (var element in waveElements)
            {
                Debug.Log($"Spawner: {_id} has {element.Count} {element.Prefab.name} prefab!");
            }
        }

        internal void SetId(int id)
        {
            _id = id;
        }
    }
}