﻿using System.Collections;
using System.Collections.Generic;
using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Waves.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        private readonly Queue<WaveElement> _waveElements = new();
        private EnemyStateMachine.Factory _enemyFactory;
        
        [Inject]
        private void Construct(EnemyStateMachine.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        internal void SetWaveData(WaveData waveData)
        {
            foreach (var waveElement in waveData.Elements)
            {
                FillQueue(waveElement);
            }
            
            StartCoroutine(nameof(SpawnCoroutine));
        }

        private void FillQueue(WaveElement element)
        {
            var count = element.Count;

            for (var i = 0; i < count; i++)
            {
                _waveElements.Enqueue(element);
            }
        }

        private IEnumerator SpawnCoroutine()
        {
            Spawn(_waveElements.Dequeue());
            
            while (_waveElements.TryDequeue(out var element))
            {
                yield return new WaitForSeconds(element.TimeToSpawn);
                Spawn(element);
            }
        }

        private void Spawn(WaveElement element)
        {
            var enemy = _enemyFactory.Create(element.Prefab);
            enemy.transform.position = transform.position;
        }
    }
}