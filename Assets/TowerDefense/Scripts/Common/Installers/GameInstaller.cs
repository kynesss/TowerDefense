using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Object, EnemyStateMachine, EnemyStateMachine.Factory>()
                .FromFactory<PrefabFactory<EnemyStateMachine>>();
        }
    }
}