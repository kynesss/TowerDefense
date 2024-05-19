using Pathfinding;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private AIPath aiPath;
        [SerializeField] private Animator animator;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyStateFactory>().AsSingle();
            Container.Bind<EnemyAnimationHandler>().AsSingle().WithArguments(animator);
            Container.Bind<IAstarAI>().FromInstance(aiPath).AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyMovementHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyHealthHandler>().AsSingle();

            BindFactories();
        }

        private void BindFactories()
        {
            Container.BindFactory<EnemyIdleState, EnemyIdleState.Factory>();
            Container.BindFactory<EnemyWalkState, EnemyWalkState.Factory>();
            Container.BindFactory<EnemyFollowState, EnemyFollowState.Factory>();
            Container.BindFactory<EnemyAttackState, EnemyAttackState.Factory>();
            Container.BindFactory<EnemyDeathState, EnemyDeathState.Factory>();
        }
    }
}