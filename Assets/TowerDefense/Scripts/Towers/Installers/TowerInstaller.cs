using TowerDefense.Scripts.Projectiles;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.Installers
{
    public class TowerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Animator animator;

        public override void InstallBindings()
        {
            BindSignals();
            BindInstances();
            BindHandlers();
            BindPools();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<TowerTargetChangedSignal>();
        }

        private void BindInstances()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(animator).AsSingle();
        }

        private void BindHandlers()
        {
            Container.BindInterfacesAndSelfTo<TowerTargetDetector>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerAttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerAnimationHandler>().AsSingle();
        }

        private void BindPools()
        {
            Container.BindMemoryPool<Projectile, Projectile.Pool>()
                .WithInitialSize(1)
                .FromComponentInNewPrefab(projectilePrefab)
                .UnderTransformGroup("Projectiles");
        }
    }
}