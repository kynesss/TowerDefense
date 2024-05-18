using Pathfinding;
using TowerDefense.AI.Scripts.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private AIPath aiPath;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyStateFactory>().AsSingle();
            Container.Bind<IAstarAI>().FromInstance(aiPath).AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyMovement>().AsSingle();

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