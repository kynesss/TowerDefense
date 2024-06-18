using TowerDefense.Scripts.Towers.Projectiles;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.Installers
{
    public class TowerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject projectilePrefab;

        public override void InstallBindings()
        {
            Container.BindInstance(transform).AsSingle();

            Container.BindInterfacesAndSelfTo<TowerTargetDetector>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerAttackHandler>().AsSingle();

            Container.BindFactory<TowerProjectile, TowerProjectile.Factory>().FromMonoPoolableMemoryPool(
                x => x.WithInitialSize(5)
                    .FromComponentInNewPrefab(projectilePrefab)
                    .UnderTransformGroup("ProjectilePool"));
        }
    }
}