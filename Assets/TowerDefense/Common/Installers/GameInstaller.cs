using TowerDefense.AI.Scripts;
using TowerDefense.Waves.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //nie mam pojęcia dlaczego Bind nie zadziałało
            Container.BindInterfacesAndSelfTo<WaveManager>().AsSingle();
            
            Container.BindFactory<Object, EnemyStateMachine, EnemyStateMachine.Factory>()
                .FromFactory<PrefabFactory<EnemyStateMachine>>();
        }
    }
}