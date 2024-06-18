using Zenject;

namespace TowerDefense.Scripts.Projectiles.Installers
{
    public class TowerProjectileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(transform).AsSingle();
            
            Container.Bind<TowerProjectileMovement>().AsSingle();
        }
    }
}