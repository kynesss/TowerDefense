using System.Collections.Generic;
using Zenject;

namespace TowerDefense.Scripts.Waves
{
    public class WaveManager : IInitializable
    {
        private readonly List<Wave> _waves;
        private readonly WaveSpawner[] _spawners;

        private int _currentWaveId;
        private Wave CurrentWave => _waves[_currentWaveId];
        
        public WaveManager(List<Wave> waves, WaveSpawner[] spawners)
        {
            _waves = waves;
            _spawners = spawners;

            UpdateSpawners();
        }
        
        public void UpdateWave()
        {
            _currentWaveId++;
        }
        
        private void UpdateSpawners()
        {
            for (var id = 0; id < _spawners.Length; id++)
            {
                var spawner = _spawners[id];
                var waveData = CurrentWave.WaveData[id];
                
                spawner.SetWaveData(waveData);
            }
        }

        public void Initialize()
        {
            
        }
    }
}