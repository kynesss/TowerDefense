using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Projectiles.Installers
{
    [CreateAssetMenu(fileName = "ProjectileSettingsInstaller", menuName = "Installers/ProjectileSettingsInstaller")]
    public class ProjectileSettingsInstaller : ScriptableObjectInstaller<ProjectileSettingsInstaller>
    {
        [SerializeField] private Settings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings.Movement).IfNotBound();
            Container.BindInstance(settings.Installer).IfNotBound();
            Container.BindInstance(settings.ArrowDamage).IfNotBound();
            Container.BindInstance(settings.StoneDamage).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public ArrowMovementHandler.Settings Movement { get; private set; }
            [field: SerializeField] public ProjectileInstaller.Settings Installer { get; private set; }
            [field: SerializeField] public ArrowDamageHandler.Settings ArrowDamage { get; private set; }
            [field: SerializeField] public StoneDamageHandler.Settings StoneDamage { get; private set; }
        }
    }
}