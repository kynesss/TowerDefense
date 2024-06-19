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
            Container.BindInstance(transform).AsSingle();
            Container.Bind<ProjectileMovementHandler>().AsSingle();
            
            BindHandlersByType();            
        }

        private void BindHandlersByType()
        {
            switch (_settings.Type)
            {
                case ProjectileType.Arrow:
                {
                    Container.Bind<IProjectileDamageHandler>().To<ArrowDamageHandler>().AsSingle();
                    break;
                }
                case ProjectileType.Stone:
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