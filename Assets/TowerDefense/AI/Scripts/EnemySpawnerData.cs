using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    [CreateAssetMenu(menuName = "EnemySpawners/EnemySpawnerData", fileName = "EnemySpawnerData")]
    public class EnemySpawnerData : ScriptableObject
    {
        [field: SerializeField] public List<EnemyWaveData> Waves { get; private set; }
        [field: SerializeField] public float SpawnRate { get; private set; }
    }
}