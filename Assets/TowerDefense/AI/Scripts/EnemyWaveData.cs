using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    [Serializable]
    public class EnemyWaveData
    {
        [field: SerializeField] public SerializedDictionary<EnemyType, int> Wave { get; private set; }
    }
}