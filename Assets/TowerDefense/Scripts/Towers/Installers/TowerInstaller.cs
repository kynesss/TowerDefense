using Zenject;

namespace TowerDefense.Scripts.Towers.Installers
{
    public class TowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TowerAttackHandler>().AsSingle();
        }
    }
}