using Pathfinding;
using TowerDefense.Scripts.AI.Signals;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private AIPath aiPath;
        [SerializeField] private Animator animator;
        [SerializeField] private Collider2D collider2d;
        
        public override void InstallBindings()
        {
            BindInstances();
            BindSignals();
            BindHandlers();
            BindFactories();
        }

        private void BindInstances()
        {
            Container.BindInstance(collider2d).IfNotBound();
            Container.BindInstance(animator).IfNotBound();
            Container.Bind<IAstarAI>().FromInstance(aiPath).AsSingle();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<EnemyHealthChangedSignal>();
        }

        private void BindHandlers()
        {
            Container.Bind<EnemyAnimationHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyMovementHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyHealthHandler>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<EnemyStateFactory>().AsSingle();
            Container.BindFactory<EnemyIdleState, EnemyIdleState.Factory>();
            Container.BindFactory<EnemyWalkState, EnemyWalkState.Factory>();
            Container.BindFactory<EnemyFollowState, EnemyFollowState.Factory>();
            Container.BindFactory<EnemyAttackState, EnemyAttackState.Factory>();
            Container.BindFactory<EnemyDeathState, EnemyDeathState.Factory>();
        }
    }
}