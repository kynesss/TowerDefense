using TowerDefense.Scripts.AI;
using TowerDefense.Scripts.Waves;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaveManager>().AsSingle();
            
            Container.BindFactory<Object, EnemyStateMachine, EnemyStateMachine.Factory>()
                .FromFactory<PrefabFactory<EnemyStateMachine>>();
        }
    }
}