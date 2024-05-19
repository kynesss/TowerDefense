using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Waves.Scripts
{
    [Serializable]
    public class Wave
    {
        [field: SerializeField] public List<WaveData> WaveData { get; private set; }
    }
}