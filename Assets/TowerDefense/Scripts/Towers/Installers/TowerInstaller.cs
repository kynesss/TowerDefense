using System;
using TowerDefense.Scripts.Projectiles;
using TowerDefense.Scripts.Towers.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.Installers
{
    public class TowerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Animator animator;

        [Inject] private Settings _settings;
        
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
            Container.BindInterfacesTo<TowerAnimationHandler>().AsSingle();

            switch (_settings.TowerType)
            {
                case TowerType.Archer:
                    Container.BindInterfacesTo<ArcherTowerAttackHandler>().AsSingle();
                    break;
                case TowerType.Stone:
                    Container.BindInterfacesTo<StoneTowerAttackHandler>().AsSingle();
                    break;
                case TowerType.Magic:
                    break;
                case TowerType.Support:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void BindPools()
        {
            Container.BindMemoryPool<Projectile, Projectile.Pool>()
                .WithInitialSize(1)
                .FromComponentInNewPrefab(projectilePrefab)
                .UnderTransformGroup("Projectiles");
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public TowerType TowerType { get; private set; }
        }
    }
}