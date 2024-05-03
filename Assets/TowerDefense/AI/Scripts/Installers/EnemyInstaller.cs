using Pathfinding;
using TowerDefense.AI.Scripts.States;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private AIPath ai;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyStateManager>().AsSingle();
            
            Container.Bind<EnemyIdleState>().AsSingle();
            Container.Bind<EnemyWalkState>().AsSingle().WithArguments(new Vector3(-18, -15, 0));
            Container.Bind<EnemyFollowState>().AsSingle();
            Container.Bind<EnemyAttackState>().AsSingle();
            Container.Bind<EnemyDeathState>().AsSingle();

            Container.Bind<IEnemyMovementHandler>().To<EnemyMovementHandler>().AsSingle()
                .WithArguments(ai);
        }
    }
}