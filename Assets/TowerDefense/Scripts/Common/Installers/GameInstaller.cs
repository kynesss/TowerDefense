using TowerDefense.Scripts.AI;
using TowerDefense.Scripts.Common.Signals;
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
            Container.DeclareSignal<TowerClickedSignal>();
            
            Container.BindInterfacesAndSelfTo<WaveManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerClickListener>().AsSingle();
            
            Container.BindFactory<Object, EnemyStateMachine, EnemyStateMachine.Factory>()
                .FromFactory<PrefabFactory<EnemyStateMachine>>();
        }
    }
}