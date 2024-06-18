using TowerDefense.Scripts.Projectiles;
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

            Container.BindMemoryPool<TowerProjectile, TowerProjectile.Pool>()
                .WithInitialSize(1)
                .FromComponentInNewPrefab(projectilePrefab)
                .UnderTransformGroup("Projectiles");
        }
    }
}