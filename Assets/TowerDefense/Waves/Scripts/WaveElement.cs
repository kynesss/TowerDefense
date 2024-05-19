using System;
using TowerDefense.AI.Scripts;
using UnityEngine;

namespace TowerDefense.Waves.Scripts
{
    [Serializable]
    public class WaveElement
    {
        [field: SerializeField] public EnemyStateMachine Prefab { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public float Rate { get; private set; }
    }
}