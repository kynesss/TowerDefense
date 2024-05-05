using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemyTest : ITickable
    {
        private readonly EnemySpawner _spawner;

        public EnemyTest(EnemySpawner spawner)
        {
            _spawner = spawner;
        }
        
        public void Tick()
        {
            if (Input.touchCount == 0)
                return;
            
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _spawner.Spawn(EnemyType.Ogre);
                    //_spawner.Spawn(EnemyType.Scorpion);
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}