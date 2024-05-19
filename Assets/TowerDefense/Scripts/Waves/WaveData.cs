using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Scripts.Waves
{
    [Serializable]
    public class WaveData
    {
        [field: SerializeField] public List<WaveElement> Elements { get; private set; }
        [field: SerializeField] public float TimeToNextWave { get; private set; }
    }
}