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
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            BindTowers();
            BindWaves();
            BindEnemies();
        }

        private void BindWaves()
        {
            Container.BindInterfacesAndSelfTo<WaveManager>().AsSingle();
        }

        private void BindEnemies()
        {
            Container.BindFactory<Object, EnemyStateMachine, EnemyStateMachine.Factory>()
                .FromFactory<PrefabFactory<EnemyStateMachine>>();
        }

        private void BindTowers()
        {
            Container.DeclareSignal<TowerClickedSignal>();
            Container.DeclareSignal<TowerBuiltSignal>();
            Container.DeclareSignal<TowerSoldSignal>();
            
            Container.BindInterfacesAndSelfTo<TowerClickListener>().AsSingle();
            Container.BindFactory<Object, TowerFacade, TowerFacade.Factory>()
                .FromFactory<PrefabFactory<TowerFacade>>();
        }
    }
}