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
            Container.BindInstance(settings.Attack).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public TowerTargetDetector.Settings Attack { get; private set; }
        }
    }
}