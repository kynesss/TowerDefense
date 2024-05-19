using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Scripts.Waves
{
    [Serializable]
    public class Wave
    {
        [field: SerializeField] public List<WaveData> WaveData { get; private set; }
    }
}