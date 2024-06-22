using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.Installers
{
    [CreateAssetMenu(fileName = "TowerSettingsInstaller", menuName = "Installers/TowerSettingsInstaller")]
    public class TowerSettingsInstaller : ScriptableObjectInstaller<TowerSettingsInstaller>
    {
        [SerializeField] private Settings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings.TargetDetector).IfNotBound();
            Container.BindInstance(settings.Attack).IfNotBound();
            Container.BindInstance(settings.Installer).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public TowerTargetDetector.Settings TargetDetector { get; private set; }
            [field: SerializeField] public TowerAttackHandler.Settings Attack { get; private set; }
            [field: SerializeField] public TowerInstaller.Settings Installer { get; private set; }
        }
    }
}