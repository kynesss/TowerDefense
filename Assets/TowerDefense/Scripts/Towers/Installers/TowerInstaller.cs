using Zenject;

namespace TowerDefense.Scripts.Towers.Installers
{
    public class TowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(transform).AsSingle();
            Container.BindInterfacesAndSelfTo<TowerTargetDetector>().AsSingle();
        }
    }
}