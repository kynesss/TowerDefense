using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Enemy enemy;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EnemyTest>().AsSingle();
            
            Container.Bind<EnemySpawner>().AsSingle().WithArguments(enemy);
            Container.BindFactory<Object, Enemy, Enemy.Factory>().FromFactory<PrefabFactory<Enemy>>();
        }
    }
}