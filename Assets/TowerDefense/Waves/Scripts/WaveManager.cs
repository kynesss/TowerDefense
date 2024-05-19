using UnityEngine;

namespace TowerDefense.Waves.Scripts
{
    public class WaveManager
    {
        private readonly WaveSpawner[] _spawners;

        public WaveManager(WaveSpawner[] spawners)
        {
            _spawners = spawners;
            InitializeSpawners();
        }

        private void InitializeSpawners()
        {
            for (var id = 0; id < _spawners.Length; id++)
            {
                var spawner = _spawners[id];
                spawner.SetId(id);
            }

            Debug.Log($"WaveManager has {_spawners.Length} spawners!");
        }
    }
}