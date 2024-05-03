using TowerDefense.Scripts.AI;
using TowerDefense.Scripts.AI.Installers;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFacade enemy;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EnemyTest>().AsSingle();
            
            Container.Bind<EnemySpawner>().AsSingle();

            Container.BindFactory<EnemyFacade, EnemyFacade.Factory>().FromSubContainerResolve()
                .ByNewPrefabInstaller<EnemyInstaller>(enemy)
                .UnderTransformGroup("Enemies");
        }
    }
}