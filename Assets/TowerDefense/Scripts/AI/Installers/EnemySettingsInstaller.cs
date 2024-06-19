using System;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.AI.Installers
{
    [CreateAssetMenu(fileName = "EnemySettingsInstaller", menuName = "Installers/EnemySettingsInstaller")]
    public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
    {
        [SerializeField] private Settings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings.Movement).IfNotBound();
            Container.BindInstance(settings.Health).IfNotBound();
            Container.BindInstance(settings.FollowState).IfNotBound();
            Container.BindInstance(settings.DeathState).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public EnemyMovementHandler.Settings Movement { get; private set; }
            [field: SerializeField] public EnemyHealthHandler.Settings Health { get; private set; }
            [field: SerializeField] public EnemyFollowState.Settings FollowState { get; private set; }
            [field: SerializeField] public EnemyDeathState.Settings DeathState { get; private set; }
        }
    }
}