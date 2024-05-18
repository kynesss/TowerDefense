using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.Installers
{
    [CreateAssetMenu(fileName = "EnemySettingsInstaller", menuName = "Installers/EnemySettingsInstaller")]
    public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
    {
        [SerializeField] private Settings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings.Movement).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public EnemyMovementHandler.Settings Movement { get; private set; }
        }
    }
}