using TowerDefense.Scripts.AI.States;
using Zenject;

namespace TowerDefense.Scripts.AI.Installers
{
    public class EnemyInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyStateManager>().AsSingle();
            
            Container.Bind<EnemyIdleState>().AsSingle();
            Container.Bind<EnemyWalkState>().AsSingle();
            Container.Bind<EnemyFollowState>().AsSingle();
            Container.Bind<EnemyAttackState>().AsSingle();
            Container.Bind<EnemyDeathState>().AsSingle();
        }
    }
}