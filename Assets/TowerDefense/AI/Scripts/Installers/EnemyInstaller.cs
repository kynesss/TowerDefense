using Pathfinding;
using TowerDefense.AI.Scripts.Signals;
using TowerDefense.AI.Scripts.States;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Animator animator;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EnemyAnimationHandler>().AsSingle().WithArguments(animator);
            
            BindSignals();
            BindStateMachine();
            BindMovement();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<EnemyStateChangedSignal>();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<EnemyStateManager>().AsSingle();
            
            Container.Bind<EnemyIdleState>().AsSingle();
            Container.Bind<EnemyWalkState>().AsSingle().WithArguments(new Vector3(-18, -15, 0));
            Container.Bind<EnemyFollowState>().AsSingle();
            Container.Bind<EnemyAttackState>().AsSingle();
            Container.Bind<EnemyDeathState>().AsSingle();
        }

        private void BindMovement()
        {
            Container.Bind<IAstarAI>().To<AIPath>().FromComponentOnRoot().AsSingle();
            Container.Bind<IEnemyMovementHandler>().To<EnemyMovementHandler>().AsSingle();
        }
    }
}