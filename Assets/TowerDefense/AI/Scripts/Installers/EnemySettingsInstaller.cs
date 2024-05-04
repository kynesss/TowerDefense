using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts.Installers
{
    [CreateAssetMenu(fileName = "EnemySettingsInstaller", menuName = "Installers/EnemySettingsInstaller")]
    public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
    {
        [SerializeField] private EnemySettings settings;
    
        public override void InstallBindings()
        {
            Container.BindInstance(settings.Movement).IfNotBound();
        }

        [Serializable]
        public class EnemySettings
        {
            public EnemyMovementHandler.Settings Movement;
        }
    }
}