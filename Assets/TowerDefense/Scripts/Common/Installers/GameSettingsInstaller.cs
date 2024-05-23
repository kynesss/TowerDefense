using System;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings.TowerClickSettings).IfNotBound();
        }

        [Serializable]
        public class GameSettings
        {
            [field: SerializeField] public TowerClickListener.Settings TowerClickSettings { get; private set; }
        }
    }
}