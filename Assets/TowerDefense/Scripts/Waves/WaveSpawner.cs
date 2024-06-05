using System.Collections;
using System.Collections.Generic;
using TowerDefense.Scripts.AI;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        private readonly Queue<WaveElement> _waveElements = new();
        
        private EnemyStateMachine.Factory _enemyFactory;
        private Transform _enemyParent;
        
        [Inject]
        private void Construct(
            EnemyStateMachine.Factory enemyFactory,
            [Inject(Id = "EnemyParent")] Transform enemyParent)
        {
            _enemyFactory = enemyFactory;
            _enemyParent = enemyParent;
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
            enemy.SetParentAndPosition(_enemyParent, transform.position);
        }
    }
}