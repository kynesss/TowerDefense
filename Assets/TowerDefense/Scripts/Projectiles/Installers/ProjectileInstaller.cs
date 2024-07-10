using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles.Installers
{
    public class ProjectileInstaller : MonoInstaller
    {
        [Inject] private Settings _settings;
        
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        public override void InstallBindings()
        {
            BindInstances();
            BindHandlers();
        }

        private void BindInstances()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
            Container.BindInstance(transform).AsSingle();
            Container.BindInstance(_rigidbody).AsSingle();
            Container.BindInstance(_animator).AsSingle();
        }

        private void BindHandlers()
        {
            Container.Bind<ProjectileAnimationHandler>().AsSingle();
            
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