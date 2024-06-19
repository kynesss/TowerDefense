using Zenject;

namespace TowerDefense.Scripts.Projectiles.Installers
{
    public class ProjectileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(transform).AsSingle();
            
            Container.Bind<ProjectileMovementHandler>().AsSingle();
        }
    }
}