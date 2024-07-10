using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles.Installers
{
    public class ProjectileInstaller : MonoInstaller
    {
        [Inject] private Settings _settings;
        

        public override void InstallBindings()
        {
            BindInstances();
            BindHandlers();
        }

        private void BindInstances()
        {
            var rb = GetComponent<Rigidbody2D>();
            Container.BindInstance(rb).AsSingle();

            if (TryGetComponent<Animator>(out var animator)) 
                Container.BindInstance(animator).AsSingle();

            Container.BindInstance(transform).AsSingle();
        }

        private void BindHandlers()
        {
            Container.Bind<ProjectileAnimationHandler>().AsSingle();
            Container.Bind<ProjectilePhysicsHandler>().AsSingle();
            
            switch (_settings.Type)
            {
                case ProjectileType.Arrow:
                    Container.Bind<IProjectileDamageHandler>().To<ArrowDamageHandler>().AsSingle();
                    Container.BindInterfacesTo<ArrowMovementHandler>().AsSingle();
                    break;
                case ProjectileType.Stone:
                    Container.Bind<IProjectileDamageHandler>().To<StoneDamageHandler>().AsSingle();
                    Container.BindInterfacesTo<StoneMovementHandler>().AsSingle();
                    break;
                case ProjectileType.Magic:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public ProjectileType Type { get; private set; }
        }
    }
}