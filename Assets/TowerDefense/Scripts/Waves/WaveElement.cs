using System;
using TowerDefense.Scripts.AI;
using UnityEngine;

namespace TowerDefense.Scripts.Waves
{
    [Serializable]
    public class WaveElement
    {
        [field: SerializeField] public EnemyStateMachine Prefab { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public float TimeToSpawn { get; private set; }
    }
}