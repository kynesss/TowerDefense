using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyStateMachine ogrePrefab;
        [SerializeField] private EnemyStateMachine scorpionPrefab;
        
        private EnemyStateMachine.Factory _enemyFactory;

        [Inject]
        private void Construct(EnemyStateMachine.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void SpawnOgre()
        {
            var ogre =_enemyFactory.Create(ogrePrefab);
            ogre.transform.position = Vector3.zero;
        }

        public void SpawnScorpion()
        {
            var scorpion = _enemyFactory.Create(scorpionPrefab);
            scorpion.transform.position = Vector3.zero;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SpawnScorpion();
            }
            
            if (Input.GetKeyDown(KeyCode.O))
            {
                SpawnOgre();
            }
        }
    }
}