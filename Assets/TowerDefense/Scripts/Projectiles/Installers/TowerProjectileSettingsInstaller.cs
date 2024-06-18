using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles.Installers
{
    [CreateAssetMenu(fileName = "TowerProjectileSettingsInstaller", menuName = "Installers/TowerProjectileSettingsInstaller")]
    public class TowerProjectileSettingsInstaller : ScriptableObjectInstaller<TowerProjectileSettingsInstaller>
    {
        [SerializeField] private Settings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings.Movement).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public TowerProjectileMovement.Settings Movement { get; private set; }
        }
    }
}