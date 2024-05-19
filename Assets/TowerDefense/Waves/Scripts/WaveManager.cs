using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TowerDefense.Waves.Scripts
{
    public class WaveManager : IInitializable
    {
        private readonly List<Wave> _waves;
        private readonly WaveSpawner[] _spawners;

        private int _currentWaveId;
        private Wave CurrentWave => _waves[_currentWaveId];
        
        public WaveManager(List<Wave> waves, WaveSpawner[] spawners)
        {
            _spawners = spawners;
            _waves = waves;
            
            Debug.Log($"Bind wave manager");
            
            UpdateSpawners();
        }

        private void UpdateSpawners()
        {
            for (var id = 0; id < _spawners.Length; id++)
            {
                var spawner = _spawners[id];
                var waveData = CurrentWave.WaveData[id];
                
                spawner.SetWaveData(waveData);
                
                Debug.Log($"Id: {id}");
            }
        }
        
        public void Initialize()
        {
            Debug.Log($"Elo");
        }
    }
}