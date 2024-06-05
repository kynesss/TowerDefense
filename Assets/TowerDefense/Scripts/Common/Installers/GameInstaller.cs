using TowerDefense.Scripts.AI;
using TowerDefense.Scripts.Common.Signals;
using TowerDefense.Scripts.Towers;
using TowerDefense.Scripts.Waves;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform enemyParentGroup;
        [SerializeField] private Transform towerParentGroup;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindWaves();
            BindEnemies();
            BindTowers();
        }

        private void BindWaves()
        {
            Container.BindInterfacesAndSelfTo<WaveManager>().AsSingle();
        }

        private void BindEnemies()
        {
            Container.BindFactory<Object, EnemyStateMachine, EnemyStateMachine.Factory>()
                .FromFactory<PrefabFactory<EnemyStateMachine>>();

            Container.Bind<Transform>().WithId("EnemyParent").FromInstance(enemyParentGroup);
        }

        private void BindTowers()
        {
            Container.DeclareSignal<TowerClickedSignal>();
            Container.DeclareSignal<TowerBuiltSignal>();
            Container.DeclareSignal<TowerSoldSignal>();
            
            Container.BindInterfacesAndSelfTo<TowerClickListener>().AsSingle();
            
            Container.BindFactory<Object, TowerFacade, TowerFacade.Factory>()
                .FromFactory<PrefabFactory<TowerFacade>>();

            Container.Bind<Transform>().WithId("TowerParent").FromInstance(towerParentGroup);
        }
    }
}