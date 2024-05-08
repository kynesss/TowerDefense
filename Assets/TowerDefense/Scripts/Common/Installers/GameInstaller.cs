using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform destination;
        [SerializeField] private EnemyPrefabsData enemyPrefabsData;
        public override void InstallBindings()
        {
            Container.BindInstance(destination.position).IfNotBound();
            Container.BindInstance(enemyPrefabsData).IfNotBound();
            
            Container.BindFactory<Object, Enemy, Enemy.Factory>().FromFactory<PrefabFactory<Enemy>>();
        }
    }
}