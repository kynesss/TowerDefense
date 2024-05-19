using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Waves.Scripts
{
    [Serializable]
    public class WaveData
    {
        [field: SerializeField] public List<WaveElement> Elements { get; private set; }
        [field: SerializeField] public float TimeToNextWave { get; private set; }
    }
}