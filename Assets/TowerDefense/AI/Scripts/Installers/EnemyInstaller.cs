using TowerDefense.AI.Scripts.States;
using Zenject;

namespace TowerDefense.AI.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyStateFactory>().AsSingle();
            
            Container.BindFactory<EnemyIdleState, EnemyIdleState.Factory>().AsSingle();
            Container.BindFactory<EnemyWalkState, EnemyWalkState.Factory>().AsSingle();
        }
    }
}