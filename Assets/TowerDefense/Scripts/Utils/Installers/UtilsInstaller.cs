using Zenject;

namespace TowerDefense.Scripts.Utils.Installers
{
    public class UtilsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AstarGridScaler>().AsSingle();
        }
    }
}