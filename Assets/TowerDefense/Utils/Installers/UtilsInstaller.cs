using Zenject;

namespace TowerDefense.Utils.Installers
{
    public class UtilsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AstarGridScaler>().AsSingle();
        }
    }
}